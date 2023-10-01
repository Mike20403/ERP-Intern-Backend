﻿using DotNetStarter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Projects
{
    public class UpdateProjectRequest
    {
        [Required]
        public string Name { get; set;}

        [Required]
        public ProjectStatus? Status { get; set; }
    }
}
