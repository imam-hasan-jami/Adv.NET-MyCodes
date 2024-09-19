﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DTOs;
using WebApplication2.EF;

namespace WebApplication2.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        dotnetDBEntities db = new dotnetDBEntities();
        public ActionResult Index()
        {
            var data = db.Posts.ToList();

            var recent = db.Posts.OrderByDescending(x => x.PostTime).Take(10).ToList();
            ViewBag.Recent = recent;

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<CommentsNew, CommentsNewDTO>();
            });
            var mapper = new Mapper(config);
            var data2 = mapper.Map<List<PostDTO>>(data);
            return View(data2);
        }

        public ActionResult CommentsNew(int id)
        {
            var data = db.Posts.Find(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<CommentsNew, CommentsNewDTO>();
            });
            var mapper = new Mapper(config);
            var post = mapper.Map<PostDTO>(data);

            var db_tags = db.Tags.ToList();
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Tag, TagDTO>();

            });
            mapper = new Mapper(config);
            var tag = mapper.Map<List<TagDTO>>(db_tags);
            ViewBag.Tags = tag;
            ViewBag.TagCount = data.PostTags.Count;
            ViewBag.Likes = data.Likes.Count;
            return View(post);
        }

        [HttpPost]
        public ActionResult Attachtags(int postId, int[] tagId)
        {
            if (tagId == null)
            {
                var post = db.Posts.Find(postId);

                foreach (var item in post.PostTags.ToList())
                {
                    db.PostTags.Remove(item);

                }
                db.SaveChanges();

            }
            else
            {
                foreach (var tag in tagId)
                {
                    db.PostTags.Add(
                            new PostTag()
                            {
                                PostId = postId,
                                TagId = tag,
                                Date = DateTime.Now,
                            }
                        );
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }
    }
}