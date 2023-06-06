namespace native_print_in_web
{
    partial class ControlForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            startButton = new Button();
            label = new Label();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Location = new Point(43, 45);
            startButton.Name = "startButton";
            startButton.Size = new Size(150, 46);
            startButton.TabIndex = 0;
            startButton.Text = "start启动";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(212, 60);
            label.Name = "label";
            label.Size = new Size(0, 31);
            label.TabIndex = 1;
            // 
            // ControlForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label);
            Controls.Add(startButton);
            Name = "ControlForm";
            Text = "Print Control";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Label label;
    }
}