using KYHBPA.Models;
using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace KYHBPA.Helpers
{
    public static class ActionLinkExtensions
    {
        public static MvcHtmlString PostLink(this HtmlHelper helper, Post post)
        {
            return helper.ActionLink(post.Title, "Post", "Blog", // TODO: Post is not an Action on BlogController?
                new
                {
                    year = post.PostedOn.Year,
                    month = post.PostedOn.Month,
                    title = post.UrlSlug
                },
                new
                {
                    title = post.Title
                });
        }

        public static MvcHtmlString CategoryLink(this HtmlHelper helper,Category category)
        {
            return helper.ActionLink(category.Name, "ViewByCategory", "Blog",
                new
                {
                    Id = category.Id
                },
                new
                {
                    title = String.Format("See all {0} posts", category.Name)
                });
        }

        public static MvcHtmlString TagLink(this HtmlHelper helper, Tag tag)
        {
            return helper.ActionLink(tag.Name, "Tag", "Blog", new { tag = tag.UrlSlug }, // TODO: Tag is not an Action on BlogController?
                new
                {
                    title = String.Format("See all posts in {0}", tag.Name)
                });
        }
    }
}