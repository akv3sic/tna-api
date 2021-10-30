using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using time_and_attendance_system_api.Models;

namespace time_and_attendance_system_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceRecordsController : ControllerBase
    {
        private readonly tnasystemContext _context;

        public AttendanceRecordsController(tnasystemContext context)
        {
            _context = context;
        }

        // GET: api/AttendanceRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceRecord>>> GetAttendanceRecords()
        {
            return await _context.AttendanceRecords.ToListAsync();
        }

        // GET: api/AttendanceRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceRecord>> GetAttendanceRecord(int id)
        {
            var attendanceRecord = await _context.AttendanceRecords.FindAsync(id);

            if (attendanceRecord == null)
            {
                return NotFound();
            }

            return attendanceRecord;
        }

        // PUT: api/AttendanceRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendanceRecord(int id, AttendanceRecord attendanceRecord)
        {
            if (id != attendanceRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(attendanceRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceRecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AttendanceRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AttendanceRecord>> PostAttendanceRecord(AttendanceRecord attendanceRecord)
        {
            _context.AttendanceRecords.Add(attendanceRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendanceRecord", new { id = attendanceRecord.Id }, attendanceRecord);
        }

        // DELETE: api/AttendanceRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendanceRecord(int id)
        {
            var attendanceRecord = await _context.AttendanceRecords.FindAsync(id);
            if (attendanceRecord == null)
            {
                return NotFound();
            }

            _context.AttendanceRecords.Remove(attendanceRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendanceRecordExists(int id)
        {
            return _context.AttendanceRecords.Any(e => e.Id == id);
        }
    }
}
