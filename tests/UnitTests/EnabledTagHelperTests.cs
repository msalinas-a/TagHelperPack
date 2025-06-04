using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TagHelperPack;
using Xunit;

namespace UnitTests
{
	public class EnabledTagHelperTests
	{
		[Fact]
		public void IsIntanceOf_TagHelper()
		{
			var helper = new EnabledTagHelper();

			Assert.IsAssignableFrom<TagHelper>(helper);
		}

		[Fact]
		public void IsEnabled_True_ByDefault()
		{
			var helper = new EnabledTagHelper();

			Assert.True(helper.IsEnabled);
		}

		[Theory]
		[InlineData(false, true)]
		[InlineData(true, false)]
		public void Process(bool isTagEnabled, bool containsDisabledAttribute)
		{
			var list = new TagHelperAttributeList();

			var context = new TagHelperContext("button", list, new Dictionary<object, object>(), "unqiueId");

			var output = new TagHelperOutput("button", list, (_, _) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()))
			{
				TagName = "button"
			};
			output.Content.SetHtmlContent("hello");

			var helper = new EnabledTagHelper
			{
				IsEnabled = isTagEnabled
			};

			helper.Process(context, output);

			Assert.Equal("button", output.TagName);
			Assert.Equal(containsDisabledAttribute, output.Attributes.ContainsName("disabled"));
		}

	}
}
