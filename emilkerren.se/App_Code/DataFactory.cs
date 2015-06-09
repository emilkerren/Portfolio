using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data.Entity;
/// <summary>
/// Summary description for DataFactory
/// </summary>
public class DataFactory
{
    private static ModelContext db = new ModelContext();
	public DataFactory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    static public void AddRating(Member userRecievingRating, int sum)
    {
        Rating rating = new Rating();
        rating.Num = sum;
        rating.Member = userRecievingRating;
        db.RatingSet.Add(rating);
        db.SaveChanges();
    }
    static public void BidOnJob(int jobId, int memberId, double sum, Member bider,Job job )
    {
        Bid bid = new Bid();
        bid.JobId = jobId;
        bid.MemberId = memberId;
        bid.Price = sum;
        bid.Member = bider;
        bid.Job = job;
        db.BidSet.Add(bid);
        db.SaveChanges();
    }
    static public Job RetrieveJob(int jobId)
    {
        var query = from j in db.JobSet
                    where j.Id == jobId
                    select j;
        return query.FirstOrDefault();
    }
    static public List<Member> RetrieveEmployers()
    {
        var query = from u in db.MemberSet
                   where u.Jobcreator == true
                    select u;
        return query.ToList<Member>();
    }
    static public List<Member> RetrieveAvailableWorkers()
    {
        var query = from u in db.MemberSet
                   where u.Jobcreator==false
                    select u;
        return query.ToList<Member>();
    }
    static public List<Job> RetrieveJobsFromEmployers()
    {
        var query = from u in db.JobSet
                    where u.UserWhoCreatedJob.Jobcreator == true
                    //&& u.MemberId != u.UserWhoCreatedJob.Id

                    select u;

            return query.ToList<Job>();
        
    }
    static public Member RetrieveUser(string username)
    {

        var query = from u in db.MemberSet
                    where u.UserName == username
                    select u;

        return query.FirstOrDefault();

    }
    static public Member RetrieveUserById(int userId)
    {

        var query = from u in db.MemberSet
                    where u.Id == userId
                    select u;

        return query.FirstOrDefault();

    }
    static public Job RetrieveJobById(int jobId)
    {

        var query = from u in db.JobSet
                    where u.Id == jobId
                    select u;

        return query.FirstOrDefault();

    }
    static public void AddJob(string title, string description, string category, string location, string askinprice, Int32 currentUserID)
    {
        Job job = new Job();
        job.Title = title;
        job.Category = category;
        job.AskingPrice = askinprice;
        job.Description = description;
        job.Location = location;
        job.MemberId = currentUserID;
        db.JobSet.Add(job);
        
        db.SaveChanges();
    }

    public static void AddJobToBider(Job selectedJob, int biderId)
    {
        Job job = new Job();
        job.Title = selectedJob.Title;
        job.Category = selectedJob.Category;
        job.AskingPrice = selectedJob.Bid.ElementAtOrDefault(0).Price.ToString();
        job.Description = selectedJob.Description;
        job.Location = selectedJob.Location;
        job.MemberId = biderId;
        db.JobSet.Add(job);
        db.SaveChanges();
    }

    public static double calculateRating(Member requestedMember, Member memberRating)
    {
        
        var result = 0;
        var tot = requestedMember.Rating.Sum(s => s.Num);
        var count = requestedMember.Rating.Count();
        if (count != 0)
        {
           result = tot / count;
        }
        else
        {
            result = 0;
        }
        return result;
    }

    public static void PostCommentOnJob(string comment, Job job, Member memberWhoPosted)
    {
        Post post = new Post();
        post.Comment = comment;
        post.Job = job;
        post.Member = memberWhoPosted;
        db.PostSet.Add(post);
        db.SaveChanges();
    }



    public static void AddTagToUser(Member currentUser, string tagText)
    {
        Tag tag = new Tag();
        tag.TagWord = tagText;
        tag.Member = currentUser;
        db.TagSet.Add(tag);
        db.SaveChanges();
    }
}