using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{

    public abstract class Document
    {

        public string Name { get; set; }

        public int Size { get; set; }

        public abstract string Display();
    }

    public class ImageDocument :Document
    {
        public PixelType PixelType{ get;set;}
        public int FrameCount { get; set; }

        public override string Display()
        {
            return "Name:" + Name + "  Size:" + Size + "  PixelType:" + PixelType + "  FrameCount:" + FrameCount;
        }
    }

    public class PDFDocument :ImageDocument
    {
        public int PdfVersion { get; set; }

        public override string Display()
        {
            return "Name:" + Name + "  Size:" + Size + "  PixelType:" + PixelType + "  FrameCount:" + FrameCount + "  PdfVersion:" + PdfVersion;
        }

        public PDFDocument(string Nm, int sz, PixelType px, int fc, int pdf)
        {
            Name = Nm;
            Size = sz;
            PixelType = px;
            FrameCount = fc;
            PdfVersion = pdf;
        }
    }

    public class TiffDocument :ImageDocument
    {
        public TiffDocument(string Nm, int sz, PixelType px, int fc)
        {
            Name = Nm;
            Size = sz;
            PixelType = px;
            FrameCount = fc;
        }
    }

    public class PlainTextDocument :Document
    {
        public string Text { get; set; }
        public override string Display()
        {
            return "Name:" + Name + "  Size:" + Size + "  Text:" + Text;
        }
        public PlainTextDocument(string Nm, int sz, string txt)
        {
            Name = Nm;
            Size = sz;
            Text = txt;
        }
    }

    public enum PixelType
    {
        Color,
        GrayScale,
        BlackAndWhite
    }

    public interface IDocumentProvider
    {
        IEnumerable<Document> GetDocuments();
    }

    public class MyDocumentProvider :IDocumentProvider
    {
        public IEnumerable<Document> GetDocuments()
        {
            yield return new PlainTextDocument("Text ABC", 400, "abcdefg");
            yield return new PlainTextDocument("Text 123", 12, "123456789");
            yield return new TiffDocument("Tiff1", 100, PixelType.Color, 10);
            yield return new TiffDocument("Tiff2", 200, PixelType.BlackAndWhite, 20);
            yield return new PDFDocument("Application1", 9000, PixelType.BlackAndWhite, 200, 2);
            yield return new PDFDocument("Application2", 3000, PixelType.Color, 100, 1);
        }
    }
}