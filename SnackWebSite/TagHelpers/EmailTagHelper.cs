using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SnackWebSite.TagHelpers
{
    //Montando link para nosso email.
    public class EmailTagHelper : TagHelper
    {
        public string? Endereco {get; set;} //endereço de email
        public string? Conteudo { get; set; } //conteúdo do email

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; //a do link 
            output.Attributes.SetAttribute("href", "mailto:"+ Endereco);
            output.Content.SetContent(Conteudo);
        }
    }
}
