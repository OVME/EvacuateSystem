using DocumentFormat.OpenXml.Packaging;

namespace Core.Classes
{
    public class DocumentMaker
    {
        protected WordprocessingDocument Template;
        protected WordprocessingDocument Document;
        protected MainDocumentPart Part;
        public DocumentMaker(string path)
        {
            Template = WordprocessingDocument.Open(path, false);
        }



       /* public void SaveTo(string path)
        {

            Document = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document,true);
            using (StreamReader streamReader = new StreamReader(Part.GetStream()))
            using (StreamWriter streamWriter = new StreamWriter(Document.MainDocumentPart.GetStream()))
            {
                streamWriter.Write(streamReader.ReadToEnd());
            }

            //Document.MainDocumentPart = Part;
            Document.Close();
        }*/
    }
}
