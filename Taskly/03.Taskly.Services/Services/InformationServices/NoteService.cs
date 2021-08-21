﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskly.Data;
using Taskly.Data.Models;
using Taskly.Services.DataTransferObjects;
using Taskly.Services.Interfaces;

namespace Taskly.Services.Services
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public NoteService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<string> AddNoteAsync(string title, string content, string colorHex, string userId)
        {
            Note note = new()
            {
                Title = title,
                Content = content,
                ColorHex = colorHex,
                CreatorId = userId
            };

            await context.Notes.AddAsync(note);
            await context.SaveChangesAsync();

            return note.Guid;
        }

        public async Task<string> AddNoteToProjectAsync(string title, string content, string colorHex, int projectId, string userId)
        {
            Note note = new()
            {
                Title = title,
                Content = content,
                ColorHex = colorHex,
                ProjectId = projectId,
                CreatorId = userId
            };

            await context.Notes.AddAsync(note);
            await context.SaveChangesAsync();

            return note.Guid;
        }

        public async Task<string> DeleteNoteAsync(int noteId)
        {
            Note note = context.Notes
                .Where(x => x.Id == noteId)
                .FirstOrDefault();

            context.Notes.Remove(note);
            await context.SaveChangesAsync();

            return note.Guid;
        }

        public async Task<string> UpdateNoteTitleAsync(int noteId, string title)
        {
            Note note = context.Notes
                .Where(x => x.Id == noteId)
                .FirstOrDefault();

            note.Title = title;
            await context.SaveChangesAsync();

            return note.Guid;
        }

        public async Task<string> UpdateNoteContentAsync(int noteId, string content)
        {
            Note note = context.Notes
                .Where(x => x.Id == noteId)
                .FirstOrDefault();

            note.Content = content;
            await context.SaveChangesAsync();

            return note.Guid;
        }

        public async Task<string> UpdateNoteColorAsync(int noteId, string colorHex)
        {
            Note note = context.Notes
                .Where(x => x.Id == noteId)
                .FirstOrDefault();

            note.ColorHex = colorHex;
            await context.SaveChangesAsync();

            return note.Guid;
        }

        public List<NoteDto> GetAllPersonalNotes()
        {
            List<NoteDto> notesDto = context.Notes
                .Where(x => x.ProjectId == null)
                .ProjectTo<NoteDto>(mapper.ConfigurationProvider)
                .ToList();

            return notesDto;
        }

        public List<NoteDto> GetAllProjectNotes(int projectId)
        {
            List<NoteDto> notesDto = context.Notes
                .Where(x => x.ProjectId == projectId)
                .ProjectTo<NoteDto>(mapper.ConfigurationProvider)
                .ToList();

            return notesDto;
        }

        public NoteDto GetNoteById(int noteId)
        {
            NoteDto noteDto = context.Notes
                .Where(x => x.Id == noteId)
                .ProjectTo<NoteDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return noteDto;
        }

        public NoteDto GetNoteByGuid(string noteGuid)
        {
            NoteDto noteDto = context.Notes
                .Where(x => x.Guid == noteGuid)
                .ProjectTo<NoteDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return noteDto;
        }
    }
}
