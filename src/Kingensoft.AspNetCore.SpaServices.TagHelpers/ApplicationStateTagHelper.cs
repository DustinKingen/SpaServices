using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Kingensoft.AspNetCore.SpaServices.TagHelpers
{
    /// <summary>
    /// Represents a tag helper that serializes the application state into the DOM.
    /// </summary>
    [HtmlTargetElement("application-state", TagStructure = TagStructure.WithoutEndTag)]
    public sealed class ApplicationStateTagHelper : TagHelper
    {
        private readonly MvcJsonOptions _jsonOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationStateTagHelper"/> class.
        /// </summary>
        /// <param name="jsonOptions">Json Options for serializer</param>
        public ApplicationStateTagHelper(IOptions<MvcJsonOptions> jsonOptions)
        {
            _jsonOptions = jsonOptions.Value ?? throw new ArgumentNullException(nameof(jsonOptions));
        }
        
        /// <summary>
        /// The application state to be serialized
        /// </summary>
        public object InitialState { get; set; }

        /// <inheritdoc />
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "script";
            output.Attributes.Add("type", "text/javascript");
            var stateJson = JsonConvert.SerializeObject(InitialState, _jsonOptions.SerializerSettings);
            output.Content.SetHtmlContent($"window.__INITIAL_STATE__ = {stateJson};");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}