using Ambermoon.Data;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class EditSpellForm : CustomForm {
    #region --- fields ----------------------------------------------------------------------------
    private readonly Models.Spell                      _spell;
    private readonly SortableBindingList<Models.Spell> _spells = [];
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public EditSpellForm(Models.Spell spell) {
      InitializeComponent();

      _spell = spell;

      cbxSchool.DataSource = Repository.Current.GameData?
        .SpellClassNames
        .Where(x => x.HasText())
        .OrderBy(x => x)
        .ToList();
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      CenterToParent();
      WireEvents();
      MapSpellToControls();
    }
    #endregion
    #region --- update combo box name -------------------------------------------------------------
    private void UpdateComboBoxName() {
      SpellSchool spellSchool = (SpellSchool)Repository.Current.GameData?
        .SpellClassNames
        .IndexOf(cbxSchool.Text)!;

      cbxName.DataSource = Repository.Current
        .GetSpellNames(spellSchool)
        .Where(x => x.HasText())
        .OrderBy(x => x)
        .ToList();
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnCancel.Click += (s, e) => Close();
      btnOK.Click += (s, e) => { MapControlsToSpell(); DialogResult = DialogResult.OK; Close(); };

      cbxSchool.SelectedIndexChanged += (s, e) => UpdateComboBoxName();
    }
    #endregion

    #region --- map controls to spell -------------------------------------------------------------
    private void MapControlsToSpell() {
      SpellSchool spellSchool = (SpellSchool)Repository.Current.GameData?
        .SpellClassNames
        .IndexOf(cbxSchool.Text)!;

      _spell.Index  = Repository.Current.GetSpellNames(spellSchool).IndexOf(cbxName.Text);
      _spell.Name   = cbxName.Text;
      _spell.School = cbxSchool.Text;
    }
    #endregion
    #region --- map spell to controls -------------------------------------------------------------
    private void MapSpellToControls() {
      cbxSchool.SelectedIndex = ((List<string>)cbxSchool.DataSource!).FindIndex(x => x == _spell.School);
      UpdateComboBoxName();
      cbxName.SelectedIndex  = ((List<string>)cbxName.DataSource!).FindIndex(x => x == _spell.Name);
    }
    #endregion
  }
}