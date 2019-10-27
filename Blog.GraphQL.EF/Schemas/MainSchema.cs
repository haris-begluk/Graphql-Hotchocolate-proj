using Blog.GraphQL.EF.Queries;
using GraphQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GraphQL.EF.Schemas
{
    public class MainSchema : global::GraphQL.Types.Schema
    {
        public MainSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MainQuery>();
        }
    }
}
