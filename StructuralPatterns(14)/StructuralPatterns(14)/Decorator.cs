using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns_14_
{
    public abstract class Text
    {
        public string Name { get; private set; }
        public Text(string _name)
        {
            Name = _name;
        }
    }
    public class DefaultText : Text
    {
        public DefaultText() : base("Текст")
        {
        }
    }
    public abstract class TextDecorator : Text
    {
        private Text text;
        public TextDecorator(string _name, Text _text) : base(_name)
        {
            text = _text;
        }
    }
    public class TextWithBorder : TextDecorator
    {
        public TextWithBorder(Text _text) : base(_text.Name + " обрамленный рамкой", _text)
        {
        }
    }
    public class BlueText : TextDecorator
    {
        public BlueText(Text _text) : base(_text.Name + " синего цвета", _text)
        {
        }
    }
    public class ShadedText : TextDecorator
    {
        public ShadedText(Text _text) : base(_text.Name + " заштрихованный", _text)
        {
        }
    }

}
