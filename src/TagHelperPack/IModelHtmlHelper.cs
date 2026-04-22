using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using System.Text.Encodings.Web;

namespace TagHelperPack;

/// <summary>
/// An <see cref="IHtmlHelper"/> with methods to generate HTML from a model.
/// </summary>
public interface IModelHtmlHelper : IHtmlHelper
{
	/// <inheritdoc cref="HtmlHelper.GenerateDisplay(ModelExplorer, string, string, object)"/>
	IHtmlContent GenerateDisplay(ModelExplorer modelExplorer, string htmlFieldName, string templateName, object additionalViewData);

	/// <inheritdoc cref="HtmlHelper.GenerateDisplayName(ModelExplorer, string)"/>
	string GenerateDisplayName(ModelExplorer modelExplorer, string expression);

	/// <inheritdoc cref="HtmlHelper.GenerateEditor(ModelExplorer, string, string, object)"/>
	IHtmlContent GenerateEditor(ModelExplorer modelExplorer, string htmlFieldName, string templateName, object additionalViewData);
}

/// <summary>
/// An <see cref="HtmlHelper"/> that implements <see cref="IModelHtmlHelper"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ModelHtmlHelper"/> class.
/// </remarks>
/// <inheritdoc cref="HtmlHelper.HtmlHelper(IHtmlGenerator, ICompositeViewEngine, IModelMetadataProvider, IViewBufferScope, HtmlEncoder, UrlEncoder)"/>
internal class ModelHtmlHelper(IHtmlGenerator htmlGenerator, ICompositeViewEngine viewEngine, IModelMetadataProvider metadataProvider, IViewBufferScope bufferScope, HtmlEncoder htmlEncoder, UrlEncoder urlEncoder) : HtmlHelper(htmlGenerator, viewEngine, metadataProvider, bufferScope, htmlEncoder, urlEncoder), IModelHtmlHelper
{

	/// <inheritdoc cref="HtmlHelper.GenerateDisplay(ModelExplorer, string, string, object)"/>
	public new IHtmlContent GenerateDisplay(ModelExplorer modelExplorer, string htmlFieldName, string templateName, object additionalViewData)
		=> base.GenerateDisplay(modelExplorer, htmlFieldName, templateName, additionalViewData);

	/// <inheritdoc cref="HtmlHelper.GenerateDisplayName(ModelExplorer, string)"/>
	public new string GenerateDisplayName(ModelExplorer modelExplorer, string expression)
		=> base.GenerateDisplayName(modelExplorer, expression);

	/// <inheritdoc cref="HtmlHelper.GenerateEditor(ModelExplorer, string, string, object)"/>
	public new IHtmlContent GenerateEditor(ModelExplorer modelExplorer, string htmlFieldName, string templateName, object additionalViewData)
		=> base.GenerateEditor(modelExplorer, htmlFieldName, templateName, additionalViewData);
}
