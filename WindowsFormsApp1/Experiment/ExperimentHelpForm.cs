using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeGaze
{
    public partial class ExperimentHelpForm : Form
    {
        public ExperimentHelpForm()
        {
            InitializeComponent();
        }
        private void fix_Click(object sender, EventArgs e)
        {
            // Fix
            this.exampleLabel.Text = "Command: \"Fix <WordToFix>\"";
            this.explainLabel.Text = "Fix Non-Words in document. If there is more then one Non-Word Choose Number.";
        }

        private void spell_Click(object sender, EventArgs e)
        {
            this.exampleLabel.Text = "Command: \"Spell <Char><Char><Char>...\"";
            this.explainLabel.Text = "Allows you to spell a word that does not exist in the suggested correction options.";
        }

        private void replace_Click(object sender, EventArgs e)
        {
            // Replace
            this.exampleLabel.Text = "Command: \"Replace <WordToReplace> <WordToReplaceTo>\"";
            this.explainLabel.Text = "Replaces a particular word that exists in the document with the new word.\nIf there is more then one Non-Word, Choose Number.";
        }

        private void replace_all_Click(object sender, EventArgs e)
        {
            this.exampleLabel.Text = "Command: \"Replace All <WordToReplace>\"";
            this.explainLabel.Text = "Replaces all instances of a particular word that exists in the document\nwith the new word";
        }

        private void change_Click(object sender, EventArgs e)
        {
            this.exampleLabel.Text = "Command: \"Change\"";
            this.explainLabel.Text = "Fix Non-Word that is closest to the mark in the document";
        }

        private void add_Click(object sender, EventArgs e)
        {
            this.exampleLabel.Text = "Command: \"Add <WordToAddFrom> <WordsToAdd>\"";
            this.explainLabel.Text = "Add a word or sequence of words after a specific word that exists in the document";
        }

        private void delete_Click(object sender, EventArgs e)
        {
            this.exampleLabel.Text = "Command: \"Delete <WordToDelete>\"";
            this.explainLabel.Text = "Delete specific word/word sequence exists in the document";
        }

        private void delete_from_Click(object sender, EventArgs e)
        {
            this.exampleLabel.Text = "Command: \"Delete <WordToDeleteFrom> To <WordToDeleteTo>\"";
            this.explainLabel.Text = "Delete phrase that starts from one word to another";
        }

        private void copy_Click(object sender, EventArgs e)
        {
            this.exampleLabel.Text = "Command: \"Copy <WordToCopy>\"";
            this.explainLabel.Text = "Copy specific word/word sequence exists in the document";
        }

        private void copy_from_Click(object sender, EventArgs e)
        {
            this.exampleLabel.Text = "Command: \"Copy <WordToCopyFrom> To <WordToCopyTo>\"";
            this.explainLabel.Text = "Copy phrase that starts from one word to another";
        }

        private void past_Click(object sender, EventArgs e)
        {
            this.exampleLabel.Text = "Command: \"Paste After\\Before <WordToPast After\\Before>\"";
            this.explainLabel.Text = "Pastes the phrase/word after a Copy command";
        }

        private void mute_unmute_Click(object sender, EventArgs e)
        {
            this.exampleLabel.Text = "Command: \"Mute\\Unmute\"";
            this.explainLabel.Text = "Enables switching on/off of listening mode to voice commands";


        }

        private void more_Click(object sender, EventArgs e)
        {
            this.exampleLabel.Text = "Command: \"More\"";
            this.explainLabel.Text = "Displays 3 more Non-Word correction options";
        }

        private void no_Click(object sender, EventArgs e)
        {
            this.exampleLabel.Text = "Command: \"No\"";
            this.explainLabel.Text = "Undo last voice command";

        }

        private void CloseHelpBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
