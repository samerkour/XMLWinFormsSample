using RACWinFormsSample.DataAccessLayer;
using RACWinFormsSample.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RACWinFormsSample
{
    public partial class AddProjectForm : Form
    {


        private string filePath = null;
        private readonly IDataProvider _dataProvider;


        #region private methods

        private void InitializeForm()
        {
            NameTextBox.Text = String.Empty;

            TypeComboBox.Items.Clear();
            TypeComboBox.Items.AddRange(new string[] { "Unknown", "Diagnostics", "Diagnostics01" });
            TypeComboBox.SelectedIndex = 0;

            ValueListBox.Items.Clear();

            AddValueButton.Enabled = true;
            EditValueButton.Enabled = false;
            DeleteValueButton.Enabled = false;
        }

        private Project ConstructPrject()
        {

            return new Model.Project()
            {

                Information = new Model.ProjectInformation()
                {
                    Name = NameTextBox.Text.Trim(),
                    Type = TypeComboBox.SelectedItem.ToString()
                },

                Data = ValueListBox.Items.Cast<decimal>().ToList()

            };
        }

        private async Task<bool> Save(Project obj)
        {
            var isSaved = false;

            if (!string.IsNullOrEmpty(filePath))
            {
                isSaved = await _dataProvider.ValidateXmlDocumentAndSaveAsync(obj, filePath);
            }
            else
            {
                // Displays a SaveFileDialog so the user can save the file
                saveFileDialog1.Filter = "Xml File|*.xml";
                saveFileDialog1.Title = "Save an XML File";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    isSaved = await _dataProvider.ValidateXmlDocumentAndSaveAsync(obj, saveFileDialog1.FileName);
                }
            }

            return isSaved;
        }

        private string ShowDialog(string lableText, string caption, string textBoxText = null)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,

            };

            Label textLabel = new Label() { Left = 50, Top = 20, Text = lableText };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Text = textBoxText };

            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };

            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }

        #endregion



        public AddProjectForm(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            InitializeComponent();
        }

        private void AddProjectForm_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

      

        private async void SaveButton_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                Project obj = ConstructPrject();
                var isSaved = await Save(obj);
                if (isSaved)
                {
                    filePath = string.Empty;
                    MessageBox.Show("Saved Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox comboBox = (ListBox)sender;

            if (ValueListBox.SelectedIndex != -1)
            {
                if (ValueListBox.SelectedItems.Count > 1)
                    MessageBox.Show("Multiple selection of values is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                EditValueButton.Enabled = true;
                DeleteValueButton.Enabled = true;
            }
        }

        private void AddValueButton_Click(object sender, EventArgs e)
        {
            try
            {
                var value = ShowDialog("Enter Value", "Add");
                if (value != null)
                    ValueListBox.Items.Add(decimal.Parse(value));
                else
                    MessageBox.Show("No Value Added. please enter a value ...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Enter decimal value...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditValueButton_Click(object sender, EventArgs e)
        {
            if (ValueListBox.SelectedIndex == -1)
            {
                MessageBox.Show("No Value Selected ... ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var value = ShowDialog("Enter Value", "Edit", ValueListBox.SelectedItem.ToString());

                ValueListBox.Items[ValueListBox.SelectedIndex] = decimal.Parse(value);
                MessageBox.Show("Value Edited...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void DeleteValueButton_Click(object sender, EventArgs e)
        {
            if (ValueListBox.SelectedIndex == -1)
            {
                MessageBox.Show("No Value Selected ... ");
            }
            else
            {
                ValueListBox.Items.RemoveAt(ValueListBox.SelectedIndex);
                MessageBox.Show("Value Deleted...");
            }
        }

        private void AddProjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
            //this.Owner.Show();

        }

        private void NameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                NameTextBox.Focus();

                // Set the ErrorProvider error with the text to display. 
                errorProvider1.SetError(NameTextBox, "Poject name is required.");
            }
            else
            {
                e.Cancel = false;
                // If all conditions have been met, clear the ErrorProvider of errors.
                errorProvider1.SetError(NameTextBox, String.Empty);
            }
        }
    }
}
