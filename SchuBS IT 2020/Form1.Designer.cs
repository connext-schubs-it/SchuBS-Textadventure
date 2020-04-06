namespace SchuBS_IT_2020
{
   partial class Form1
   {
      /// <summary>
      /// Erforderliche Designervariable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Verwendete Ressourcen bereinigen.
      /// </summary>
      /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Vom Windows Form-Designer generierter Code

      /// <summary>
      /// Erforderliche Methode für die Designerunterstützung.
      /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
      /// </summary>
      private void InitializeComponent()
      {
         this.labelLocation = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // labelLocation
         // 
         this.labelLocation.AutoSize = true;
         this.labelLocation.Location = new System.Drawing.Point(12, 9);
         this.labelLocation.Name = "labelLocation";
         this.labelLocation.Size = new System.Drawing.Size(48, 13);
         this.labelLocation.TabIndex = 0;
         this.labelLocation.Text = "Location";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.labelLocation);
         this.Name = "Form1";
         this.Text = "Textadventure";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

        #endregion

        private System.Windows.Forms.Label labelLocation;
    }
}

