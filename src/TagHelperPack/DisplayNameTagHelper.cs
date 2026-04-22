using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace TagHelperPack;

/// <summary>
/// Renders the display name for the specified model expression.
/// </summary>
/// <remarks>
/// Creates a new instance of the <see cref="DisplayNameTagHelper" /> class.
/// </remarks>
/// <param name="htmlHelper">The <see cref="IHtmlHelper"/>.</param>
[HtmlTargetElement("display-name", Attributes = "for", TagStructure = TagStructure.WithoutEndTag)]
public class DisplayNameTagHelper(IHtmlHelper htmlHelper) : TagHelper
{

	/// <summary>
	/// An expression to be evaluated against the current model.
	/// </summary>
	[HtmlAttributeName("for")]
	public ModelExpression For { get; set; }

	/// <summary>
	/// Gets or sets the <see cref="ViewContext"/>.
	/// </summary>
	[HtmlAttributeNotBound]
	[ViewContext]
	public ViewContext ViewContext { get; set; }

	/// <inheritdoc />
	public override void Process(TagHelperContext context, TagHelperOutput output)
	{
		ArgumentNullException.ThrowIfNull(context);

		ArgumentNullException.ThrowIfNull(output);

		if (context.SuppressedByAspIf() || context.SuppressedByAspAuthz())
		{
			return;
		}

		((IViewContextAware)htmlHelper).Contextualize(ViewContext);

		output.PostContent.AppendHtml(htmlHelper.DisplayName(For));

		output.TagName = null;
	}
}
