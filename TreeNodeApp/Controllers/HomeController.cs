using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeNodeApp.Models;

namespace TreeNodeApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var allParents = db.TreeNodes.Where(x=>x.node_parent_id == null).ToList();
            return View(allParents);
        }

        [Authorize]
        public ActionResult Create(int id)
        {
            TreeNode newTreeNode = new TreeNode();
            if (id > 0)
            {
                newTreeNode.node_parent_id = id;
                newTreeNode.ParentNode = db.TreeNodes.Find(id);
            }
            return View(newTreeNode);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(TreeNode treeNode)
        {
            db.TreeNodes.Add(treeNode);
            db.SaveChanges();
            return View("Index");
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            TreeNode newTreeNode = db.TreeNodes.Find(id);
            return View(newTreeNode);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(TreeNode treeNode)
        {
            db.TreeNodes.Add(treeNode);
            db.Entry(treeNode).State = EntityState.Modified;
            db.SaveChanges();
            return View("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            TreeNode deleteTreeNode = db.TreeNodes.Find(id);
            foreach (var child in deleteTreeNode.TreeNodeChilds.ToList())
                db.TreeNodes.Remove(child);
            db.TreeNodes.Remove(deleteTreeNode);
            db.SaveChanges();
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}