using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace May_23.Models
{
    public class CandidatesRepository
    {
        private string _connectionString;

        public CandidatesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCandidate(Candidate candidate)
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                context.Candidates.InsertOnSubmit(candidate);
                context.SubmitChanges();
            }
        }

        public IEnumerable<Candidate> GetPending()
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.Where(c => c.Status == Models.Status.Pending).ToList();
            }
        }

        public IEnumerable<Candidate> GetConfirmed()
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.Where(c => c.Status == Models.Status.Confirmed).ToList();
            }
        }

        public IEnumerable<Candidate> GetRefused()
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.Where(c => c.Status == Models.Status.Refused).ToList();
            }
        }

        public Candidate ViewDetails(int candidateId)
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.FirstOrDefault(c => c.Id == candidateId);
            }
        }

        public void Confirm(int candidateId)
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                context.ExecuteCommand("UPDATE Candidates SET Status = 1 WHERE Id = {0}", candidateId);
            }
        }

        public void Refuse(int candidateId)
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                context.ExecuteCommand("UPDATE Candidates SET Status = 2 WHERE Id = {0}", candidateId);
            }
        }

        public int GetPendingCount()
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.Count(c => c.Status == Status.Pending);
            }
        }

        public int GetConfirmedCount()
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.Count(c => c.Status == Status.Confirmed);
            }
        }

        public int GetRefusedCount()
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.Count(c => c.Status == Status.Refused);
            }
        }

    }
}