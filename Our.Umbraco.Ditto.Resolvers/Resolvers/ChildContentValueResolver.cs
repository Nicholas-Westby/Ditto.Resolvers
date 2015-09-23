﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Our.Umbraco.Ditto.Resolvers.Resolvers
{
    public class ChildContentValueResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            var content = Context.Instance as IPublishedContent;
            var descriptor = Context.PropertyDescriptor;

            if (content != null && descriptor != null && content.Children != null && content.Children.Any())
            {
                // [ML] - As we actually have stuff to do now, generate a list please if required

                var propertyType = descriptor.PropertyType;
                var isGenericType = propertyType.IsGenericType;
                var targetType = isGenericType ? propertyType.GenericTypeArguments.First() : propertyType;

                if (!isGenericType)
                {
                    return content.FirstChild().As(targetType);
                }

                // [ML] - Create a list

                var listType = typeof(List<>).MakeGenericType(targetType);
                var list = (IList)Activator.CreateInstance(listType);

                foreach (var child in content.Children.OfType<PublishedContentModel>())
                {
                    var model = child.As(targetType);

                    if (model != null)
                    {
                        list.Add(model);
                    }
                }

                return list;
            }

            return null;
        }
    }
}