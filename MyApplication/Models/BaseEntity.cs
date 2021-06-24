namespace Models
{
	public abstract class BaseEntity : object
	{
		protected BaseEntity() : base()
		{
			//Id = new System.Guid();

			Id = System.Guid.NewGuid();
		}

		// **********
		[System.ComponentModel.DataAnnotations.Key]
		[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
			(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
		public System.Guid Id { get; set; }
		// **********
	}
}
