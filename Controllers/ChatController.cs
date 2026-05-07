using MedicalAppBackend.Data;
using MedicalAppBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChatController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("between/{user1Id}/{user2Id}")]
        public async Task<IActionResult> GetOrCreateChat(int user1Id, int user2Id)
        {
            var chat = await _context.Chats
                .FirstOrDefaultAsync(c =>
                    (c.IdUserSender == user1Id && c.IdUserReciver == user2Id) ||
                    (c.IdUserSender == user2Id && c.IdUserReciver == user1Id));

            if (chat == null)
            {
                chat = new Chats
                {
                    IdUserSender = user1Id,
                    IdUserReciver = user2Id,
                    CreatedAt = DateTime.UtcNow,
                    Active = true
                };
                _context.Chats.Add(chat);
                await _context.SaveChangesAsync();
            }

            return Ok(chat);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserChats(int userId)
        {
            var chats = await _context.Chats
                .Where(c => c.IdUserSender == userId || c.IdUserReciver == userId)
                .ToListAsync();

            var chatList = new List<object>();
            foreach (var chat in chats)
            {
                var otherUserId = chat.IdUserSender == userId ? chat.IdUserReciver : chat.IdUserSender;
                var otherUser = await _context.Users.FindAsync(otherUserId);

                chatList.Add(new
                {
                    chat.IdChat,
                    OtherUserId = otherUserId,
                    OtherUserName = otherUser != null ? $"{otherUser.Firstname} {otherUser.Lastname}" : "Unknown",
                    chat.CreatedAt
                });
            }

            return Ok(chatList);
        }

        [HttpGet("{chatId}/messages")]
        public async Task<IActionResult> GetMessages(int chatId)
        {
            var messages = await _context.ChatMessages
                .Where(m => m.IdChat == chatId)
                .OrderBy(m => m.CreateDate)
                .Select(m => new
                {
                    m.IdChatMessage,
                    m.IdChat,
                    m.Message,
                    m.CreateDate,
                    m.IdUserSender
                })
                .ToListAsync();

            return Ok(messages);
        }

        [HttpPost("message")]
        public async Task<IActionResult> SaveMessage(ChatMessages message)
        {
            message.CreateDate = DateTime.UtcNow;
            message.Active = true;
            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
            return Ok(message);
        }
    }
}