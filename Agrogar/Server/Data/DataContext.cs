namespace Agrogar.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<WorkPhase> WorkPhase { get; set; }
        public DbSet<TaskType> TaskType { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			string pHString1 = "B1D1CB1930979E4A7928044D6F744B65714398576BE211A5ABDD8D3F1FDE8EC858BCD78A5EA11EB3336B775CC3B286B4E3AF34431138A51ACB4F40A90830F869";
			byte[] passwordHash1 = Enumerable.Range(0, pHString1.Length / 2)
										 .Select(x => Convert.ToByte(pHString1.Substring(x * 2, 2), 16))
										 .ToArray();
			string pSString1 = "768D0405712AE9F996481749F4E4F381792FF0B1AB9C98808FE8DD5D5720C1DD30011A6C919D535E6A8722B9A5D296153CD10C699D95BE013ADBE02BB65E46E34DB9C7926E93C20F6388D15FC36011DD414740006DC41DE449129544F8F8A3B5591D8468095F1DDE1917F93856CE38FED65772391B3BCA254D9212B9564D2BCF";
			byte[] passwordSalt1 = Enumerable.Range(0, pSString1.Length / 2)
										 .Select(x => Convert.ToByte(pSString1.Substring(x * 2, 2), 16))
										 .ToArray();

			string pHString2 = "0BE3CC891D8B6E88A716740AED5B5C8715E3E2AB6D95149D8B45914D56EE150DF8388516708BB1FCCC3A797BEA37B4AEEDCEAE4D921BA758CFA33D49EE19F75D";
			byte[] passwordHash2 = Enumerable.Range(0, pHString2.Length / 2)
										 .Select(x => Convert.ToByte(pHString2.Substring(x * 2, 2), 16))
										 .ToArray();
			string pSString2 = "869844A5DB7F9EB13DCD12DA5A6DFAAA4F16F3D518650D7745D3E61D056038B586D0893167096D3D3F518658DDED569C6B923A395E82AD03AC2B3BB8A5586A2061ED61933967E34B2CD65D5823F00AB7A1DC8308269919F90E71D1D40CE30294719ECC96C5960BBC31D6C4C8FBBE1F36FF3660D271DF07153CEA5589D006C895";
			byte[] passwordSalt2 = Enumerable.Range(0, pSString2.Length / 2)
										 .Select(x => Convert.ToByte(pSString2.Substring(x * 2, 2), 16))
										 .ToArray();

			

			modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 1,
					Name = "Test",
					Email = "Test@Te.st",
					PasswordHash = passwordHash1,
					PasswordSalt = passwordSalt1,
					DateCreated = DateTime.Now,
					PhoneNumber = "1234567890",
					LicensePP = true
				},
				new User
				{
					Id = 2,
					Name = "Test2",
					Email = "Test2@Te.st",
					PasswordHash = passwordHash1,
					PasswordSalt = passwordSalt1,
					DateCreated = DateTime.Now,
					PhoneNumber = "1234567890",
					LicensePP = true
				}
				);


			modelBuilder.Entity<Category>().HasData(
					new Category
					{
						Id = 1,
						Name = "Campo de cultivo",
						Url = "images/fields.png"
					},
					new Category
					{
						Id = 2,
						Name = "Huerto Frutal",
						Url = "images/treefield.png"
					},
					new Category
					{
						Id = 3,
						Name = "Invernadero",
						Url = "images/greenhouse.png"
					},
					new Category
					{
						Id = 4,
						Name = "Almacen",
						Url = "images/warehouse.png"
					}
				);

			modelBuilder.Entity<WorkPhase>().HasData(
					new WorkPhase
					{
						Id = 1,
						Name = "Preparación del suelo"
					},
					new WorkPhase
					{
						Id = 2,
						Name = "Siembra"
					},
					new WorkPhase
					{
						Id = 3,
						Name = "Riego"
					},
					new WorkPhase
					{
						Id = 4,
						Name = "Control de Biodiversidad"
					},
					new WorkPhase
					{
						Id = 5,
						Name = "Mantenimiento"
					},
					new WorkPhase
					{
						Id = 6,
						Name = "Fertilización"
					},
					new WorkPhase
					{
						Id = 7,
						Name = "Cosecha"
					}
				);

			modelBuilder.Entity<TaskType>().HasData(
					new TaskType
					{
						Id = 1,
						Name = "Arar",
						WorkPhaseId = 1
					},
					new TaskType
					{
						Id = 2,
						Name = "Nivelar",
						WorkPhaseId = 1
					},
					new TaskType
					{
						Id = 3,
						Name = "Abonar",
						WorkPhaseId = 1
					},
					new TaskType
					{
						Id = 4,
						Name = "Sembrar",
						WorkPhaseId = 2
					},
					new TaskType
					{
						Id = 5,
						Name = "Inundación",
						WorkPhaseId = 3
					},
					new TaskType
					{
						Id = 6,
						Name = "Gravedad",
						WorkPhaseId = 3
					},
					new TaskType
					{
						Id = 7,
						Name = "Aspersión",
						WorkPhaseId = 3
					},
					new TaskType
					{
						Id = 8,
						Name = "Goteo",
						WorkPhaseId = 3
					},
					new TaskType
					{
						Id = 9,
						Name = "Hidropónico",
						WorkPhaseId = 3
					},
					new TaskType
					{
						Id = 10,
						Name = "Fumigar",
						WorkPhaseId = 4
					},
					new TaskType
					{
						Id = 11,
						Name = "Escardar",
						WorkPhaseId = 4
					},
					new TaskType
					{
						Id = 12,
						Name = "Quemar",
						WorkPhaseId = 4
					},
					new TaskType
					{
						Id = 13,
						Name = "Poda",
						WorkPhaseId = 5
					},
					new TaskType
					{
						Id = 14,
						Name = "Reparación",
						WorkPhaseId = 5
					},
					new TaskType
					{
						Id = 15,
						Name = "Limpieza",
						WorkPhaseId = 5
					},
					new TaskType
					{
						Id = 16,
						Name = "Fertilizar",
						WorkPhaseId = 6
					},
					new TaskType
					{
						Id = 17,
						Name = "Recogida",
						WorkPhaseId = 7
					},
					new TaskType
					{
						Id = 18,
						Name = "Transporte",
						WorkPhaseId = 7
					}
				);

			modelBuilder.Entity<JobTitle>().HasData(
					new JobTitle
					{
						Id = 1,
						Name = "Conductor de Tractor"

					},
					new JobTitle
					{
						Id = 2,
						Name = "Peón"

					},
					new JobTitle
					{
						Id = 3,
						Name = "Operario"
					},
					new JobTitle
					{
						Id = 4,
						Name = "Conductor de Camión"
					}
				);


			modelBuilder.Entity<Property>().HasData(
					new Property
					{
						Id = 1,
						UserId = 1,
						CategoryId = 1,
						WorkPhaseId = 2,
						Size = 3,
						Crop = "Trigo",
						CadasterReference = "33054A026001080000RI",
						Municipality = "Las Regueras",
						Province = "Asturias"
					},
					new Property
					{
						Id = 2,
						UserId = 1,
						CategoryId = 1,
						WorkPhaseId = 7,
						Size = 3,
						Crop = "Maiz",
						CadasterReference = "52014A011002030000KJ",
						Municipality = "Carreño",
						Province = "Asturias"
					},
					new Property
					{
						Id = 3,
						UserId = 2,
						CategoryId = 3,
						WorkPhaseId = 3,
						Size = 3,
						Crop = "Fresa",
						CadasterReference = "52014A011001880000KP",
						Municipality = "Carreño",
						Province = "Asturias"
					},
					new Property
					{
						Id = 4,
						UserId = 2,
						CategoryId = 4,
						WorkPhaseId = 5,
						Size = 3,
						Crop = "Nave industrial",
						CadasterReference = "52076A101004200000LL",
						Municipality = "Villaviciosa",
						Province = "Asturias"
					}

				);

			
		}





	}
}
