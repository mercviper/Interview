using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyDocumentProvider myDocs = new MyDocumentProvider();
            
            Console.WriteLine("All documents:");

            foreach (Document d in myDocs.GetDocuments())
            {
                Console.WriteLine(d.Display());
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Documents over 200 Size:");


            foreach (Document d in myDocs.GetDocuments())
            {  
                if(d.Size > 200)
                    Console.WriteLine(d.Display());
            }
            
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Documents over 200 Size and is a PDF:");


            foreach (Document d in myDocs.GetDocuments())
            {
                if(d.Size >200 && d is PDFDocument)
                    Console.WriteLine(d.Display());
            }
            
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("All Color Documents:");

            foreach (Document d in myDocs.GetDocuments())
            {
                if (d is ImageDocument)
                {
                    ImageDocument i = (ImageDocument)d;
                    if (i.PixelType == PixelType.Color)
                        Console.WriteLine(d.Display());
                }
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("All PdfVersion = 2 Documents:");

            foreach (Document d in myDocs.GetDocuments())
            {
                if (d is PDFDocument)
                {
                    PDFDocument p = (PDFDocument)d;
                    if (p.PdfVersion == 2)
                        Console.WriteLine(d.Display());
                }
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Sorted by Size:");

            foreach (Document d in myDocs.GetDocuments().OrderBy(d=>d.Size))
            {
                Console.WriteLine(d.Display());
            }
            Console.Read();
        }
    }
}
