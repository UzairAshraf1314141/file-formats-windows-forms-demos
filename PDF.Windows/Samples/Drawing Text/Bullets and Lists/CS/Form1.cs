#region Copyright Syncfusion Inc. 2001 - 2021
//
//  Copyright Syncfusion Inc. 2001 - 2021. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
//
#endregion

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Lists;
using Syncfusion.Windows.Forms;
using Syncfusion.Licensing;

namespace EssentialPDFSamples
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : MetroForm
    {
        # region Private Members
        private Label label1;
        private Button button1;
        private PictureBox pictureBox1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        # endregion

        # region Constructors
        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.MinimizeBox = true;
            Application.EnableVisualStyles();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //           
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(-1, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 92);
            this.label1.TabIndex = 27;
            this.label1.Text = "Click the button to view an PDF document generated by Essential PDF.  Please note" +
                " that Adobe Reader or its equivalent is required to view the resultant document." +
                "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            //this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(288, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 26;
            this.button1.Text = "PDF";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = System.Drawing.Image.FromFile(GetFullTemplatePath("pdf_header.png", true));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(373, 89);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
           // this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(373, 203);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
               this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(GetFullTemplatePath("syncfusion.ico", true));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bullets and Lists";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			SyncfusionLicenseProvider.RegisterLicense(DemoCommon.FindLicenseKey());
            Application.Run(new Form1());
        }
        # endregion

        # region Events
        private void button1_Click(object sender, System.EventArgs e)
        {
            //Create a new instance of PdfDocument class.
            PdfDocument document = new PdfDocument();

            //Add a new page to the document.
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            SizeF sizef = page.Graphics.ClientSize;

            //Create an unordered list
            PdfUnorderedList list = new PdfUnorderedList();

            //Set the marker style
            list.Marker.Style = PdfUnorderedMarkerStyle.Disk;

            //Create font and write title
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);
            graphics.DrawString("List Features", font, PdfBrushes.DarkBlue, new PointF(225, 10));

            string[] products = { "Tools", "Grid", "Chart", "Edit", "Diagram", "XlsIO", "Grouping", "Calculate", "PDF", "HTMLUI", "DocIO" };
            string[] IO = { "XlsIO", "PDF", "DocIO" };

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Regular);
            graphics.DrawString("This sample demonstrates various features of bullets and lists. A list can be ordered and unordered. Essential PDF provides support for creating and formatting ordered and unordered lists.", font, PdfBrushes.Black, new RectangleF(0, 50, sizef.Width, sizef.Height));

            //Create string format
            PdfStringFormat format = new PdfStringFormat();
            format.LineSpacing = 10f;

            font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10, PdfFontStyle.Bold);

            // Format list
            list.Font = font;
            list.StringFormat = format;

            //Set list indent
            list.Indent = 10;

            //Add items to the list
            list.Items.Add("List of Essential Studio products");
            list.Items.Add("IO products");

            //Set text indent
            list.TextIndent = 10;

            //Create Ordered list as sublist of parent list
            PdfOrderedList subList = new PdfOrderedList();
            subList.Marker.Brush = PdfBrushes.Black;
            subList.Indent = 20;
            list.Items[0].SubList = subList;

            //Set format for sub list
            font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10, PdfFontStyle.Italic);
            subList.Font = font;
            subList.StringFormat = format;
            foreach (string s in products)
            {
                //Add items
                subList.Items.Add(string.Concat("Essential ", s));
            }

            //Create unorderd sublist for the second item of parent list
            PdfUnorderedList SubsubList = new PdfUnorderedList();
            SubsubList.Marker.Brush = PdfBrushes.Black;
            SubsubList.Indent = 20;
            list.Items[1].SubList = SubsubList;

            PdfImage image = PdfImage.FromFile(GetFullTemplatePath("syncfusion_logo.gif", true));
            font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10, PdfFontStyle.Regular);
            SubsubList.Font = font;
            SubsubList.StringFormat = format;

            //Add subitems
            SubsubList.Items.Add("Essential PDF: It is a .NET library with the capability to produce Adobe PDF files. It features a full-fledged object model for the easy creation of PDF files from any .NET language. It does not use any external libraries and is built from scratch in C#. It can be used on the server side (ASP.NET or any other environment) or with Windows Forms applications. Essential PDF supports many features for creating a PDF document. Drawing Text, Images, Shapes, etc can be drawn easily in the PDF document.");
            SubsubList.Items.Add("Essential DocIO: It is a .NET library that can read and write Microsoft Word files. It features a full-fledged object model similar to the Microsoft Office COM libraries. It does not use COM interop and is built from scratch in C#. It can be used on systems that do not have Microsoft Word installed. Here are some of the most common questions that arise regarding the usage and functionality of Essential DocIO.");
            SubsubList.Items.Add("Essential XlsIO: It is a .NET library that can read and write Microsoft Excel files (BIFF 8 format). It features a full-fledged object model similar to the Microsoft Office COM libraries. It does not use COM interop and is built from scratch in C#. It can be used on systems that do not have Microsoft Excel installed, making it an excellent reporting engine for tabular data. ");

            //Set image as marker
            SubsubList.Marker.Image = image;

            //Draw list
            list.Draw(page, new RectangleF(0, 130, sizef.Width, sizef.Height));

            // Save and close the document.
            document.Save("Sample.pdf");
            document.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
#if NETCORE
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.pdf")
                {
                    UseShellExecute = true
                };
                process.Start();
#else
                System.Diagnostics.Process.Start("Sample.pdf");
#endif
                this.Close();
            }
            else
            {
                // Exit
                this.Close();
            }
        }
        # endregion

        # region Helpher Methods
        /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName, bool image)
        {
#if NETCORE
            string fullPath = @"..\..\..\..\..\..\..\..\Common\";
#else
            string fullPath = @"..\..\..\..\..\..\..\Common\";
#endif
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }       
        # endregion
    }
	/// <summary>
    /// Represents a class that is used to find the licensing file for Syncfusion controls.
    /// </summary>
    public class DemoCommon
    {

        /// <summary>
        /// Finds the license key from the Common folder.
        /// </summary>
        /// <returns>Returns the license key.</returns>
        public static string FindLicenseKey()
        {
#if NETCORE
            string licenseKeyFile = @"..\\..\Common\\SyncfusionLicense.txt";
#else
            string licenseKeyFile = "..\\Common\\SyncfusionLicense.txt";
#endif
            for (int n = 0; n < 20; n++)
            {
                if (!System.IO.File.Exists(licenseKeyFile))
                {
                    licenseKeyFile = @"..\" + licenseKeyFile;
                    continue;
                }
                return System.IO.File.ReadAllText(licenseKeyFile);
            }
            return string.Empty;
        }
    }
}
