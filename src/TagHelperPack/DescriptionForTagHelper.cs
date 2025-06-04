using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace TagHelperPack;

/// <summary>
/// Appends the display description for the specified model expression.
/// </summary>
[HtmlTargetElement("*", Attributes = ForAttributeName)]
public sealed class DescriptionForTagHelper : TagHelper
{
	private const string ForAttributeName = "asp-description-for";

	/// <summary>
	/// An expression to be evaluated against the current model.
	/// </summary>
	[HtmlAttributeName(ForAttributeName)]
	public ModelExpression For { get; set; } = default!;

	/// <inheritdoc />
	public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
	{
		ArgumentNullException.ThrowIfNull(context);

		ArgumentNullException.ThrowIfNull(output);

		if (context.SuppressedByAspIf() || context.SuppressedByAspAuthz())
		{
			return;
		}

		var description = For.Metadata.Description;
		if (description != null)
		{
			// Do not update the content if another tag helper targeting this element has already done so.
			if (!output.IsContentModified)
			{
				var childContent = await output.GetChildContentAsync();
				if (childContent.IsEmptyOrWhiteSpace)
				{
					output.Content.SetHtmlContent(description);
				}
				else
				{
					output.Content.SetHtmlContent(childContent);
				}
			}
		}
	}
}