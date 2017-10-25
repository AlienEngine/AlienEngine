namespace AlienEngine.UI
{
	public class ContextMenuEntry : Button
	{
		public ContextMenuEntry(Gui gui) : base(gui)
		{
			SkinEnabled = Gui.Skin.ContextMenuEntryEnabled;
			SkinPressed = Gui.Skin.ContextMenuEntryPressed;
			SkinHover = Gui.Skin.ContextMenuEntryHover;
			SkinDisabled = Gui.Skin.ContextMenuEntryDisabled;

			Click += (s, e) => Gui.CloseContextMenu();
		}
	}
}
