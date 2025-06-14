using System.Threading.Tasks;
using Business.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppProject.Controllers;

public class ProjectsController(IProjectService projectService) : Controller
{

    private readonly IProjectService _projectService = projectService;

    public async Task<IActionResult> Index()
    {

        var model = new ProjectViewMdoel
        {
            Projects = await _projectService.GetProjectsAsync()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddProjectViewModel model)
    {
        var addProjectFormData = model.MapTo<AddProjectFormData>();

        var result = await _projectService.CreateProjectAsync(addProjectFormData);
        return Json(new { });

    }

    [HttpPost]
    public IActionResult Update(EditProjectViewModel model)
    {
        return Json(new {});
    }

    [HttpPost]
    public IActionResult Delete(string id)
    {
        return Json(new {});
    }
    


}

