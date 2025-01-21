using Blog_site.Entities;
using Blog_site.Extentions;
using Blog_site.Filters;
using Blog_site.Repositories;
using Blog_site.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc;
namespace Blog_site.Controllers
{
    public class PostController: Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            IndexVM vm = new IndexVM();

            PostRepository postRepository = new PostRepository();
            CommentRepository commentRepository = new CommentRepository();
            vm.Posts = postRepository.GetAll();
            vm.Comments = commentRepository.GetAll();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(IndexVM vm)
        {
            PostRepository postRepository = new PostRepository();
            Posts post = postRepository.GetById(vm.Id);
            post.Likes++;

            postRepository.Save(post);

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM vm)
        {
            Posts post = new Posts();

            post.OwnerId = HttpContext.Session.GetObject<User>("loggedUser").Id;
            post.Title = vm.Title;
            post.Description = vm.Description;
            post.Type = vm.Type;
            post.CreatedAt = DateTime.Now;

            PostRepository postRepository = new PostRepository();
            postRepository.Save(post);

            return RedirectToAction("Index", "Post");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PostRepository postRepository = new PostRepository();
            Posts post = postRepository.GetById(id);

            EditVM vm = new EditVM();
            vm.Id = id;
            vm.Title = post.Title;
            vm.Description = post.Description;
            vm.Type = post.Type;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditVM vm)
        {
            Posts post = new Posts();

            post.Id = vm.Id;
            post.Title = vm.Title;
            post.Description = vm.Description;
            post.Type = vm.Type;
            post.CreatedAt = DateTime.Now;

            PostRepository postRepository = new PostRepository();
            postRepository.Save(post);

            return RedirectToAction("Index", "Post");
        }

        public IActionResult Delete(int id)
        {
            PostRepository repo = new PostRepository();

            Posts toDelete = repo.GetById(id);

            if (toDelete != null)
                repo.Delete(toDelete);

            return RedirectToAction("Index", "Posts");
        }
    }
}
