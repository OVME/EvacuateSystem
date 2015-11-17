using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EvacuateSystem.Model.Classes;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;

namespace Core.Classes
{
    public class ResettlementDocumentMaker : DocumentMaker
    {
        public ResettlementDocumentMaker(string path) : base(path)
        {
        }

        public void MakeResettlementDocument(Evacuated ev, Adress ad, string path)
        {
            if (Template != null)
            {
                //Body body = new Body(Template.MainDocumentPart.Document.Body.Elements().ToList());

                Document = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document);
                Document.AddMainDocumentPart();
                var s = Template.MainDocumentPart.Document.InnerXml;


                s = s.Replace("EvacuatedSurname", ev.Surname);
                s = s.Replace("EvacuatedName", ev.Name);
                s = s.Replace("EvacuatedPatronomic", ev.Patronomic);
                s = s.Replace("EvacuatedDocNum", ev.NumberOfDocument);
                s = s.Replace("EvacuatedDocData", ev.DocumentData);
                 s = s.Replace("EvacuatedDateOfBirth", ev.DateOfBirth.ToString("d"));
                 if (ev.DocumentType != null) s = s.Replace("EvacuatedDocType", ev.DocumentType.TypeName);
                 else s=s.Replace("EvacuatedDocType", "_________");
                 
                //for adress
                s = s.Replace("AdressOwnerName", ad.OwnerName);
                if(ad.Village!=null&&ad.Street!=null)s = s.Replace("AdressAdress", ad.Village.Name + " " + ad.Street.Title + " " + ad.HouseNumber);
                s = s.Replace("AdressSquare", ad.Square.ToString());
                s = s.Replace("AdressOwnerDocData", ad.OwnerDocData);





                Document.MainDocumentPart.AddPart(Template.MainDocumentPart.StyleDefinitionsPart);
                    

                Paragraph p = new Paragraph(new Run(new Text("")));

                


                Document.MainDocumentPart.Document =
                      new Document(
                        new Body(
                         p));
                
                Document.MainDocumentPart.Document.InnerXml = s;
                
                
                Document.MainDocumentPart.Document.Save();
                Document.Close();


            }

            
        }
    }
}
