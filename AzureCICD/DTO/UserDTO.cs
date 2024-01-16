﻿using System.ComponentModel.DataAnnotations;

namespace AzureCICD.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Content { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
