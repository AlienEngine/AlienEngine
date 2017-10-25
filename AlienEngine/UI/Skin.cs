using System.Drawing;
using AlienEngine.Core.Rendering.Fonts;
using Font = AlienEngine.Core.Rendering.Fonts.Font;

namespace AlienEngine.UI
{
    public class Skin
    {
        public struct FormSkin
        {
            public Font Font;
            public Color4 Color;
            public Padding Border;
            public Color4 BorderColor;
            public Color4 BackgroundColor;
        }

        public struct ButtonSkin
        {
            public Font Font;
            public Color4 Color;
            public FontAlignment TextAlign;
            public Padding Border;
            public Color4 BorderColor;
            public Color4 BackgroundColor;
        }

        public struct LabelSkin
        {
            public Font Font;
            public Color4 Color;
            public FontAlignment TextAlign;
            public Padding Padding;
            public Color4 BackgroundColor;
        }

        public struct TextBoxSkin
        {
            public Font Font;
            public Color4 Color;
            public Color4 SelectionColor;
            public FontAlignment TextAlign;
            public Padding Border;
            public Padding Padding;
            public Color4 BorderColor;
            public Color4 BackgroundColor;
        }

        public struct CheckBoxSkin
        {
            public Font Font;
            public Color4 Color;
            public Padding Border;
            public Color4 BorderColor;
            public Color4 BackgroundColor;
        }

        public struct GroupLayoutSkin
        {
            public Padding Border;
            public Color4 BorderColor;
            public Color4 BackgroundColor;
        }

        public struct FlowLayoutSkin
        {
            public Padding Padding;
            public Padding Border;
            public Color4 BorderColor;
            public Color4 BackgroundColor;
            public int Space;
        }

        public struct SplitLayoutSkin
        {
            public Color4 BackgroundColor;
            public int SplitterSize;
        }

        public struct SliderSkin
        {
            public Color4 KnobColor;
            public Color4 BackgroundColor;
        }

        public struct ScrollableControlSkin
        {
            public Padding Border;
            public Color4 BorderColor;
            public Color4 BackgroundColor;
        }

        public FormSkin FormActive = new FormSkin();
        public FormSkin FormInactive = new FormSkin();

        public ButtonSkin ButtonEnabled = new ButtonSkin();
        public ButtonSkin ButtonDisabled = new ButtonSkin();
        public ButtonSkin ButtonHover = new ButtonSkin();
        public ButtonSkin ButtonPressed = new ButtonSkin();

        public LabelSkin LabelEnabled = new LabelSkin();
        public LabelSkin LabelDisabled = new LabelSkin();

        public LabelSkin LinkLabelEnabled = new LabelSkin();
        public LabelSkin LinkLabelDisabled = new LabelSkin();

        public TextBoxSkin TextBoxEnabled = new TextBoxSkin();
        public TextBoxSkin TextBoxActive = new TextBoxSkin();
        public TextBoxSkin TextBoxHover = new TextBoxSkin();
        public TextBoxSkin TextBoxDisabled = new TextBoxSkin();

        public CheckBoxSkin CheckBoxEnabled = new CheckBoxSkin();
        public CheckBoxSkin CheckBoxPressed = new CheckBoxSkin();
        public CheckBoxSkin CheckBoxHover = new CheckBoxSkin();
        public CheckBoxSkin CheckBoxDisabled = new CheckBoxSkin();

        public GroupLayoutSkin GroupLayout = new GroupLayoutSkin();

        public FlowLayoutSkin FlowLayout = new FlowLayoutSkin();

        public SplitLayoutSkin SplitLayout = new SplitLayoutSkin();

        public SliderSkin SliderEnabled = new SliderSkin();
        public SliderSkin SliderDisabled = new SliderSkin();
        public SliderSkin SliderHover = new SliderSkin();
        public SliderSkin SliderPressed = new SliderSkin();

        public ScrollableControlSkin ScrollableControl = new ScrollableControlSkin();

        public FlowLayoutSkin ContextMenu = new FlowLayoutSkin();

        public ButtonSkin ContextMenuEntryEnabled = new ButtonSkin();
        public ButtonSkin ContextMenuEntryDisabled = new ButtonSkin();
        public ButtonSkin ContextMenuEntryHover = new ButtonSkin();
        public ButtonSkin ContextMenuEntryPressed = new ButtonSkin();

        public Skin(Font defaultFont = null)
        {
            if (defaultFont == null)
                defaultFont = new Font(new System.Drawing.Font("Arial", 8.0f));

            FormActive.Font = defaultFont;
            FormActive.Color = Color.FromArgb(240, 240, 240);
            FormActive.Border = new Padding(2);
            FormActive.BorderColor = Color.FromArgb(192, 56, 56, 56);
            FormActive.BackgroundColor = Color.FromArgb(41, 41, 41);

            FormInactive.Font = defaultFont;
            FormInactive.Color = Color.FromArgb(160, 160, 160);
            FormInactive.Border = new Padding(2);
            FormInactive.BorderColor = Color.FromArgb(192, 56, 56, 56);
            FormInactive.BackgroundColor = Color.FromArgb(41, 41, 41);


            ButtonEnabled.Font = defaultFont;
            ButtonEnabled.Color = Color.FromArgb(240, 240, 240);
            ButtonEnabled.TextAlign = FontAlignment.Centre;
            ButtonEnabled.Border = new Padding(2);
            ButtonEnabled.BorderColor = Color.FromArgb(56, 56, 56);
            ButtonEnabled.BackgroundColor = Color.Transparent;

            ButtonDisabled.Font = defaultFont;
            ButtonDisabled.Color = Color.FromArgb(128, 128, 128);
            ButtonDisabled.TextAlign = FontAlignment.Centre;
            ButtonDisabled.Border = new Padding(2);
            ButtonDisabled.BorderColor = Color.FromArgb(56, 56, 56);
            ButtonDisabled.BackgroundColor = Color.Transparent;

            ButtonHover.Font = defaultFont;
            ButtonHover.Color = Color.FromArgb(255, 255, 255);
            ButtonHover.TextAlign = FontAlignment.Centre;
            ButtonHover.Border = new Padding(2);
            ButtonHover.BorderColor = Color.FromArgb(64, 64, 64);
            ButtonHover.BackgroundColor = Color.Transparent;

            ButtonPressed.Font = defaultFont;
            ButtonPressed.Color = Color.FromArgb(96, 96, 96);
            ButtonPressed.TextAlign = FontAlignment.Centre;
            ButtonPressed.Border = new Padding(2);
            ButtonPressed.BorderColor = Color.FromArgb(32, 32, 32);
            ButtonPressed.BackgroundColor = Color.Transparent;


            LabelEnabled.Font = defaultFont;
            LabelEnabled.Color = Color.FromArgb(192, 192, 192);
            LabelEnabled.TextAlign = FontAlignment.Left;
            LabelEnabled.Padding = new Padding(1, 1, 1, 1);
            LabelEnabled.BackgroundColor = Color.Transparent;

            LabelDisabled.Font = defaultFont;
            LabelDisabled.Color = Color.FromArgb(128, 128, 128);
            LabelDisabled.TextAlign = FontAlignment.Left;
            LabelDisabled.Padding = new Padding(1, 1, 1, 1);
            LabelDisabled.BackgroundColor = Color.Transparent;


            LinkLabelEnabled.Font = defaultFont;
            LinkLabelEnabled.Color = Color.FromArgb(128, 128, 255);
            LinkLabelEnabled.TextAlign = FontAlignment.Left;
            LinkLabelEnabled.Padding = new Padding(1, 1, 1, 1);
            LinkLabelEnabled.BackgroundColor = Color.Transparent;

            LinkLabelDisabled.Font = defaultFont;
            LinkLabelDisabled.Color = Color.FromArgb(96, 96, 192);
            LinkLabelDisabled.TextAlign = FontAlignment.Left;
            LinkLabelDisabled.Padding = new Padding(1, 1, 1, 1);
            LinkLabelDisabled.BackgroundColor = Color.Transparent;


            TextBoxEnabled.Font = defaultFont;
            TextBoxEnabled.Color = Color.FromArgb(192, 192, 192);
            TextBoxEnabled.SelectionColor = Color.FromArgb(80, 80, 80);
            TextBoxEnabled.TextAlign = FontAlignment.Left;
            TextBoxEnabled.Border = new Padding(1);
            TextBoxEnabled.Padding = new Padding(1, 0, 1, 2);
            TextBoxEnabled.BorderColor = Color.FromArgb(96, 96, 96);
            TextBoxEnabled.BackgroundColor = Color.FromArgb(56, 56, 56);

            TextBoxActive.Font = defaultFont;
            TextBoxActive.Color = Color.FromArgb(192, 192, 192);
            TextBoxActive.SelectionColor = Color.FromArgb(96, 96, 96);
            TextBoxActive.TextAlign = FontAlignment.Left;
            TextBoxActive.Border = new Padding(1);
            TextBoxActive.Padding = new Padding(1, 0, 1, 2);
            TextBoxActive.BorderColor = Color.FromArgb(255, 192, 96);
            TextBoxActive.BackgroundColor = Color.FromArgb(56, 56, 56);

            TextBoxHover.Font = defaultFont;
            TextBoxHover.Color = Color.FromArgb(192, 192, 192);
            TextBoxHover.SelectionColor = Color.FromArgb(80, 80, 80);
            TextBoxHover.TextAlign = FontAlignment.Left;
            TextBoxHover.Border = new Padding(1);
            TextBoxHover.Padding = new Padding(1, 0, 1, 2);
            TextBoxHover.BorderColor = Color.FromArgb(128, 128, 128);
            TextBoxHover.BackgroundColor = Color.FromArgb(56, 56, 56);

            TextBoxDisabled.Font = defaultFont;
            TextBoxDisabled.Color = Color.FromArgb(128, 128, 128);
            TextBoxDisabled.SelectionColor = Color.FromArgb(80, 80, 80);
            TextBoxDisabled.TextAlign = FontAlignment.Left;
            TextBoxDisabled.Border = new Padding(1);
            TextBoxDisabled.Padding = new Padding(1, 0, 1, 2);
            TextBoxDisabled.BorderColor = Color.FromArgb(128, 128, 128);
            TextBoxDisabled.BackgroundColor = Color.FromArgb(56, 56, 56);


            CheckBoxEnabled.Font = defaultFont;
            CheckBoxEnabled.Color = Color.FromArgb(192, 192, 192);
            CheckBoxEnabled.Border = new Padding(1);
            CheckBoxEnabled.BorderColor = Color.FromArgb(96, 96, 96);
            CheckBoxEnabled.BackgroundColor = Color.FromArgb(56, 56, 56);

            CheckBoxPressed.Font = defaultFont;
            CheckBoxPressed.Color = Color.FromArgb(192, 192, 192);
            CheckBoxPressed.Border = new Padding(1);
            CheckBoxPressed.BorderColor = Color.FromArgb(255, 192, 96);
            CheckBoxPressed.BackgroundColor = Color.FromArgb(56, 56, 56);

            CheckBoxHover.Font = defaultFont;
            CheckBoxHover.Color = Color.FromArgb(192, 192, 192);
            CheckBoxHover.Border = new Padding(1);
            CheckBoxHover.BorderColor = Color.FromArgb(128, 128, 128);
            CheckBoxHover.BackgroundColor = Color.FromArgb(56, 56, 56);

            CheckBoxDisabled.Font = defaultFont;
            CheckBoxDisabled.Color = Color.FromArgb(128, 128, 128);
            CheckBoxDisabled.Border = new Padding(1);
            CheckBoxDisabled.BorderColor = Color.FromArgb(128, 128, 128);
            CheckBoxDisabled.BackgroundColor = Color.FromArgb(56, 56, 56);


            GroupLayout.Border = new Padding(1);
            GroupLayout.BorderColor = Color.Transparent; //Color.FromArgb(96, 96, 96);
            GroupLayout.BackgroundColor = Color.Transparent; //Color.FromArgb(240, 240, 240);


            FlowLayout.Padding = new Padding(2);
            FlowLayout.Border = new Padding(0);
            FlowLayout.BorderColor = Color.Transparent;
            FlowLayout.BackgroundColor = Color.Transparent;
            FlowLayout.Space = 2;


            SplitLayout.BackgroundColor = Color.FromArgb(0, 0, 0);
            SplitLayout.SplitterSize = 1;


            SliderEnabled.KnobColor = Color.FromArgb(80, 80, 80);
            SliderEnabled.BackgroundColor = Color.FromArgb(28, 28, 28); //Color.FromArgb(56, 56, 56);

            SliderDisabled.KnobColor = Color.Transparent; //Color.FromArgb(96, 96, 96);
            SliderDisabled.BackgroundColor = Color.FromArgb(28, 28, 28); //Color.FromArgb(56, 56, 56);

            SliderHover.KnobColor = Color.FromArgb(96, 96, 96);
            SliderHover.BackgroundColor = Color.FromArgb(32, 32, 32);

            SliderPressed.KnobColor = Color.FromArgb(80, 80, 80);
            SliderPressed.BackgroundColor = Color.FromArgb(32, 32, 32);


            ScrollableControl.Border = new Padding(1);
            ScrollableControl.BorderColor = Color.FromArgb(56, 56, 56);
            ScrollableControl.BackgroundColor = Color.FromArgb(41, 41, 41);


            ContextMenu.Padding = new Padding(1);
            ContextMenu.Border = new Padding(1);
            ContextMenu.BorderColor = Color.FromArgb(128, 128, 128);
            ContextMenu.BackgroundColor = Color.FromArgb(32, 32, 32);
            ContextMenu.Space = 1;


            ContextMenuEntryEnabled.Font = defaultFont;
            ContextMenuEntryEnabled.Color = Color.FromArgb(240, 240, 240);
            ContextMenuEntryEnabled.TextAlign = FontAlignment.Left;
            ContextMenuEntryEnabled.Border = new Padding(2);
            ContextMenuEntryEnabled.BorderColor = Color.FromArgb(56, 56, 56);
            ContextMenuEntryEnabled.BackgroundColor = Color.Transparent;

            ContextMenuEntryDisabled.Font = defaultFont;
            ContextMenuEntryDisabled.Color = Color.FromArgb(128, 128, 128);
            ContextMenuEntryDisabled.TextAlign = FontAlignment.Left;
            ContextMenuEntryDisabled.Border = new Padding(2);
            ContextMenuEntryDisabled.BorderColor = Color.FromArgb(56, 56, 56);
            ContextMenuEntryDisabled.BackgroundColor = Color.Transparent;

            ContextMenuEntryHover.Font = defaultFont;
            ContextMenuEntryHover.Color = Color.FromArgb(255, 255, 255);
            ContextMenuEntryHover.TextAlign = FontAlignment.Left;
            ContextMenuEntryHover.Border = new Padding(2);
            ContextMenuEntryHover.BorderColor = Color.FromArgb(64, 64, 64);
            ContextMenuEntryHover.BackgroundColor = Color.Transparent;

            ContextMenuEntryPressed.Font = defaultFont;
            ContextMenuEntryPressed.Color = Color.FromArgb(96, 96, 96);
            ContextMenuEntryPressed.TextAlign = FontAlignment.Left;
            ContextMenuEntryPressed.Border = new Padding(2);
            ContextMenuEntryPressed.BorderColor = Color.FromArgb(32, 32, 32);
            ContextMenuEntryPressed.BackgroundColor = Color.Transparent;
        }
    }
}