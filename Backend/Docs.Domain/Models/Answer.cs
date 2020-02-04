namespace Docs.Domain.Models
{
	public class Answer : BaseEntity
	{
		public string Content { get; set; }
		public int QuestionId { get; set; }
		public virtual Question Question { get; set; }
	}
}