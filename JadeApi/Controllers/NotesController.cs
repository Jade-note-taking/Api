﻿using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JadeApi.Data;
using JadeApi.Entities;
using JadeApi.Helpers;
using JadeApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace JadeApi.Controllers;

[Route("Notes")]
[ApiController]
public class NotesController(CosmosClient cosmosClient, JadeDbContext context) : Controller
{
    [Authorize]
    [HttpGet("")]
    public async Task<ActionResult> All()
    {
        var userId = User.Claims.GetUserId();
        var query = context.Notes.AsQueryable().Where(n => n.UserId == userId && n.Archive == false);
        var results = await query.ToListAsync();

        return Ok(results);
    }

    [Authorize]
    [HttpGet("archive")]
    public async Task<ActionResult> Archive()
    {
        var userId = User.Claims.GetUserId();
        var query = context.Notes.AsQueryable().Where(n => n.UserId == userId && n.Archive == true);
        var results = await query.ToListAsync();

        return Ok(results);
    }

    [Authorize]
    [HttpGet("content/{noteId}")]
    public async Task<ActionResult> NoteContent(string noteId)
    {
        var userId = User.Claims.GetUserId();
        var cosmosNoteId = MD5.HashData(Encoding.UTF8.GetBytes($"{userId}{noteId}")).ToHex();

        try
        {
            var note = await cosmosClient.GetContainer().ReadItem<CosmosNote>(cosmosNoteId);
            return Ok(note.Content);
        }
        catch
        {
            return NotFound();
        }
    }

    [Authorize]
    [HttpGet("{noteId}")]
    public async Task<ActionResult> Note(string noteId)
    {
        var userId = User.Claims.GetUserId();
        var query = context.Notes.AsQueryable().Where(n => n.UserId == userId && n.Id == noteId);
        var note = await query.FirstAsync();

        return Ok(note);
    }
}
