namespace ProjectAandB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Globalization;
    using System.Linq;


    public class DbContextDal : DbContext
    {

        public DbContextDal() : base("BdContextDal_ConnectionString_appConfig3")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<Course> courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }


        public virtual DbSet<ConstraintPractitionerCourse> constraintPractitionerCourses { get; set; } 
        public virtual DbSet<ConstrainLecturerCourse> constrainLectureCourses { get; set; } 
        public virtual DbSet<ApprovalOfPractitioner> approvePractitionersCourse { get; set; }
        public virtual DbSet<ApprovalOfLecture> approveLecturersCourse { get; set; } 
        
        public virtual DbSet<ClassRoom> class_rooms { get; set; }
        public virtual DbSet<Admin> admins { get; set; }
        public virtual DbSet<Practitioner> practitiners { get; set; }
        public virtual DbSet<Secretary> secretaries { get; set; }
        public virtual DbSet<Lecturer> lecturers { get; set; }        
        public virtual DbSet<Constraint> constraints { get; set; }
        public virtual DbSet<Lecture> LessonLectures { get; set; }
        public virtual DbSet<Practise> LessonPractises { get; set; }
        public virtual DbSet<Lab> LessonLabs { get; set; }
        public virtual DbSet<StudentFeeForm> StudentsFeeForms { get; set; }
        public virtual DbSet<StudentStudyForm> StudentsStudyForms { get; set; }

        public virtual DbSet<Registrar> Registrars { get; set; }
        public virtual DbSet<Grader> Graders { get; set; }
        public virtual DbSet<StudentCoordinator> StudentCoordinators { get; set; }
        public virtual DbSet<CollectiveMessage> CollectiveMessages { get; set; }
        public virtual DbSet<StudentsRegisterToLessonLabs> studentRegisterdLessonLabs { get; set; }
        public virtual DbSet<StudentsRegisterToLessonLectures> studentRegisterdLessonLectures { get; set; }
        public virtual DbSet<StudentsRegisterToLessonPractises> studentRegisterdLessonPractises { get; set; }


       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Secretary>().HasKey(Secretary => Secretary.ID);
            modelBuilder.Entity<Admin>().HasKey(Admin => Admin.ID);
            modelBuilder.Entity<Lecturer>().HasKey(Lecturer => Lecturer.ID);
            modelBuilder.Entity<Student>().HasKey(student => student.ID);
            modelBuilder.Entity<Course>().HasKey(course => course.ID);
            modelBuilder.Entity<Practitioner>().HasKey(practitiner => practitiner.ID);
            modelBuilder.Entity<ApprovalOfPractitioner>().HasKey(approvalOfPractitioner => new { approvalOfPractitioner.PractitionerId, approvalOfPractitioner.CourseId });
            modelBuilder.Entity<ApprovalOfLecture>().HasKey(approvalOfLecture => new { approvalOfLecture.LecturerId, approvalOfLecture.CourseId });
            modelBuilder.Entity<Enrollment>().HasKey(enrollment => new { enrollment.StudentId, enrollment.CourseId });
            modelBuilder.Entity<Constraint>().HasKey(constraint => constraint.ID);
            modelBuilder.Entity<Lecture>().HasKey(lecture => new
            {
                lecture.Day,
                lecture.Start,
                lecture.lecturerID,
                lecture.CourseId
            });

            modelBuilder.Entity<Practise>().HasKey(Practise => new { Practise.Day, Practise.Start, Practise.practitionerID, Practise.CourseId });
            modelBuilder.Entity<Lab>().HasKey(lab => new { lab.Day, lab.Start, lab.practitionerID, lab.CourseId});



            modelBuilder.Entity<StudentsRegisterToLessonLabs>().HasKey(srl => new { srl.StudentId, srl.LessonDay, srl.LessonStart});
            modelBuilder.Entity<StudentsRegisterToLessonLectures>().HasKey(srl => new { srl.StudentId, srl.LessonDay, srl.LessonStart });
            modelBuilder.Entity<StudentsRegisterToLessonPractises>().HasKey(srl => new { srl.StudentId, srl.LessonDay, srl.LessonStart });


            // define many-to-many between Lesson to Student - 
            modelBuilder.Entity<Student>()
                .HasMany(student => student.RegisteredLessonLabs)
                .WithRequired(lessonsResitred => lessonsResitred.Student)
                .HasForeignKey(LessonsResitred => LessonsResitred.StudentId);
            modelBuilder.Entity<Lab>()
                .HasMany(lesson => lesson.studentRegistered)
                .WithRequired(studentRegistered => studentRegistered.lab)
                .HasForeignKey(studentRegistered => new { studentRegistered.LessonDay, studentRegistered.LessonStart, studentRegistered.practitionerID, studentRegistered.CourseID});

            modelBuilder.Entity<Student>()
               .HasMany(student => student.RegisteredLessonPractises)
               .WithRequired(lessonsResitred => lessonsResitred.Student)
               .HasForeignKey(LessonsResitred => LessonsResitred.StudentId);
            modelBuilder.Entity<Practise>()
                .HasMany(lesson => lesson.studentRegistered)
                .WithRequired(studentRegistered => studentRegistered.Practise)
                .HasForeignKey(studentRegistered => new { studentRegistered.LessonDay, studentRegistered.LessonStart, studentRegistered.practitionerID, studentRegistered.CourseID});

            modelBuilder.Entity<Student>()
               .HasMany(student => student.RegisteredLessonLectures)
               .WithRequired(lessonsResitred => lessonsResitred.Student)
               .HasForeignKey(LessonsResitred => LessonsResitred.StudentId);
            modelBuilder.Entity<Lecture>()
                .HasMany(lesson => lesson.studentRegistered)
                .WithRequired(studentRegistered => studentRegistered.lecture)
                .HasForeignKey(studentRegistered => new { studentRegistered.LessonDay, studentRegistered.LessonStart, studentRegistered.lectureID, studentRegistered.CourseID});

            
            

            // define many-to-many between course to Student - to save Grade
            modelBuilder.Entity<Constraint>()
                .HasRequired(constraint => constraint.course)
                .WithMany()
                .HasForeignKey(constraint => constraint.courseID)
                .WillCascadeOnDelete(false);

            // define many to one between enrollment to course 
            modelBuilder.Entity<Enrollment>().
                HasRequired<Course>(x => x.Course).
                WithMany(y => y.Enrollments).
                HasForeignKey(z => z.CourseId);

            // define many to one between enrollment to student 
            modelBuilder.Entity<Enrollment>().
                HasRequired<Student>(x => x.Student).
                WithMany(y => y.Enrollments).
                HasForeignKey(z => z.StudentId);

            // define many-to-many between course to Student - to save Grade
            modelBuilder.Entity<Student>()
                .HasMany(student => student.Enrollments)
                .WithRequired(enrollment => enrollment.Student)
                .HasForeignKey(enrollment => enrollment.StudentId);
            modelBuilder.Entity<Course>()
                .HasMany(course => course.Enrollments)
                .WithRequired(enrollment => enrollment.Course)
                .HasForeignKey(enrollment => enrollment.CourseId);


            // define many-to-many between course to Lecturer - to save ApprovedCourseBySecretary
            modelBuilder.Entity<Lecturer>()
                .HasMany(lecturerer => lecturerer.approvalOfLectures)
                .WithRequired(approvalOfLecture => approvalOfLecture.Lecturer)
                .HasForeignKey(approvalOfLecture => approvalOfLecture.LecturerId);
            modelBuilder.Entity<Course>()
               .HasMany(course => course.approvalOfLectures)
               .WithRequired(approvalOfLectures => approvalOfLectures.Course)
               .HasForeignKey(approvalOfLectures => approvalOfLectures.CourseId);

            // define many-to-many between course to Practitioner - to save ApprovedCourseBySecretary
            modelBuilder.Entity<Practitioner>()
                .HasMany(practitiner => practitiner.approvalOfPractitioners)
                .WithRequired(approvalOfPractitioner => approvalOfPractitioner.practitioner)
                .HasForeignKey(approvalOfPractitioner => approvalOfPractitioner.PractitionerId);
            modelBuilder.Entity<Course>()
               .HasMany(course => course.approvalOfPractitioners)
               .WithRequired(approvalOfPractitioners => approvalOfPractitioners.Course)
               .HasForeignKey(approvalOfPractitioners => approvalOfPractitioners.CourseId);


            // define many-to-many between course to Lecturer to Constraint
            modelBuilder.Entity<Lecturer>()
                .HasMany(lecturerer => lecturerer.constrainLectureCourses)
                .WithRequired(constrainLectureCourse => constrainLectureCourse.Lecturer)
                .HasForeignKey(constrainLectureCourse => constrainLectureCourse.LectureId);
            modelBuilder.Entity<Course>()
                .HasMany(course => course.constrainLectureCourses)
                .WithRequired(constrainLectureCourses => constrainLectureCourses.Course)
                .HasForeignKey(constrainLectureCourses => constrainLectureCourses.CourseId);
            modelBuilder.Entity<Constraint>()
                .HasMany(constraint => constraint.constrainLectureCourses)
                .WithRequired(constrainLectureCourses => constrainLectureCourses.Constraint)
                .HasForeignKey(constrainLectureCourses => constrainLectureCourses.ConstraintID);


            // define many-to-many between course to Practitioner to Constraint - to save Boolean AfterLecturer
            modelBuilder.Entity<Practitioner>()
                .HasMany(practitiner => practitiner.constraintPractitionerCourses)
                .WithRequired(constraintPractitionerCourses => constraintPractitionerCourses.Practitiner)
                .HasForeignKey(constraintPractitionerCourses => constraintPractitionerCourses.practotinerId);
            modelBuilder.Entity<Course>()
                .HasMany(course => course.constraintPractitionerCourses)
                .WithRequired(constraintPractitionerCourses => constraintPractitionerCourses.Course)
                .HasForeignKey(constraintPractitionerCourses => constraintPractitionerCourses.CourseId);
            modelBuilder.Entity<Constraint>()
                .HasMany(constraint => constraint.constraintPractitionerCourses)
                .WithRequired(constraintPractitionerCourses => constraintPractitionerCourses.Constraint)
                .HasForeignKey(constraintPractitionerCourses => constraintPractitionerCourses.ConstraintID);


            // define many-to-many between course to Lecture - to connection to lecture
            modelBuilder.Entity<Lecturer>()
                .HasMany(lecturer => lecturer.LessonLectures)
                .WithRequired(Lectures => Lectures.lecturer)
                .HasForeignKey(Lectures => Lectures.lecturerID);
            modelBuilder.Entity<Course>()
               .HasMany(course => course.LessonLectures)
               .WithRequired(LessonLectures => LessonLectures.Course)
               .HasForeignKey(LessonLectures => LessonLectures.CourseId);


            // define many-to-many between course to Practitioner - to connection to Practise
            modelBuilder.Entity<Practitioner>()
                .HasMany(practitiner => practitiner.LessonPractises)
                .WithRequired(LessonPractises => LessonPractises.practitioner)
                .HasForeignKey(LessonPractises => LessonPractises.practitionerID);
            modelBuilder.Entity<Course>()
               .HasMany(course => course.LessonPractises)
               .WithRequired(LessonPractises => LessonPractises.Course)
               .HasForeignKey(LessonPractises => LessonPractises.CourseId);
            
        }
    }
}