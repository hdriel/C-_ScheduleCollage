using ProjectAandB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ProjectAandB.Tests
{
    [TestClass()]
    public class GeneralFuntionTests
    {
        private Mock<Student> std;
        private Mock<Course> c1;
        private Mock<Course> c2;
        private Mock<Course> c3;
        private Mock<Course> c4;
        private Mock<Lecturer> lec;
        private Mock<Practitioner> prac;
        private Mock<User> user1;
        private Mock<StaffMember> staff1;


        // ==========================================================================================
        //                               HADRIEL & LEVAN
        private void initMocks()
        {
            std = new Mock<Student>();
            std.Setup(x => x.ID).Returns(100);

            c1 = new Mock<Course>();
            c1.Setup(x => x.ID).Returns(900);
            c2 = new Mock<Course>();
            c2.Setup(x => x.ID).Returns(901);
            c3 = new Mock<Course>();
            c3.Setup(x => x.ID).Returns(902);
            c4 = new Mock<Course>();
            c4.Setup(x => x.ID).Returns(903);


            var listEnrollment = new List<Enrollment> { new Enrollment { StudentId = std.Object.ID, CourseId = c1.Object.ID, Grade = 80 },
                                                        new Enrollment { StudentId = std.Object.ID, CourseId = c2.Object.ID, Grade = 90 },
                                                        new Enrollment { StudentId = std.Object.ID, CourseId = c3.Object.ID, Grade = 70 }};

            std.Setup(x => x.Enrollments).Returns(listEnrollment);

            lec = new Mock<Lecturer>();
            lec.Setup(x => x.ID).Returns(300);

            var listApprovedCourse1 = new List<ApprovalOfLecture> {  new ApprovalOfLecture { CourseId = c1.Object.ID, LecturerId = lec.Object.ID, Approved = true },
                                                                    new ApprovalOfLecture { CourseId = c2.Object.ID, LecturerId = lec.Object.ID, Approved = true },
                                                                    new ApprovalOfLecture { CourseId = c3.Object.ID, LecturerId = lec.Object.ID, Approved = false },};
            lec.Setup(x => x.approvalOfLectures).Returns(listApprovedCourse1);



            prac = new Mock<Practitioner>();
            prac.Setup(x => x.ID).Returns(400);


            var listApprovedCourse2 = new List<ApprovalOfPractitioner> {  new ApprovalOfPractitioner { CourseId = c1.Object.ID, PractitionerId = lec.Object.ID, Approved = false },
                                                                          new ApprovalOfPractitioner { CourseId = c2.Object.ID, PractitionerId = lec.Object.ID, Approved = true },
                                                                          new ApprovalOfPractitioner { CourseId = c3.Object.ID, PractitionerId = lec.Object.ID, Approved = false },};

            prac.Setup(x => x.approvalOfPractitioners).Returns(listApprovedCourse2);

            initLessonLecture();
            initLessonLabs();
            initLessonPractise();

            initLessonStudent();
        }
        private void initLessonLecture()
        {
            List<Lecture> listLessons = new List<Lecture>() { new Lecture() { building = "F", number = 202, CourseId = c1.Object.ID, Day = "Sunday", LCourseID = c1.Object.ID, Start = 10, End = 14, projector = true, lecturerID = lec.Object.ID, LTeacherID = lec.Object.ID, NumStudent = 10 },
            new Lecture() { building = "S", number = 404, CourseId = c2.Object.ID, Day = "Monday", LCourseID = c1.Object.ID, Start = 10, End = 11, projector = true, lecturerID = lec.Object.ID, LTeacherID = lec.Object.ID, NumStudent = 10 },
            new Lecture() { building = "A", number = 152, CourseId = c4.Object.ID, Day = "Friday", LCourseID = c1.Object.ID, Start = 8, End = 11, projector = true, lecturerID = lec.Object.ID, LTeacherID = lec.Object.ID, NumStudent = 10 },
            new Lecture() { building = "M", number = 100, CourseId = c3.Object.ID, Day = "Monday", LCourseID = c1.Object.ID, Start = 15, End = 18, projector = true, lecturerID = lec.Object.ID, LTeacherID = lec.Object.ID, NumStudent = 10 }};

            lec.Setup(x => x.LessonLectures).Returns(listLessons);
        }
        private void initLessonLabs()
        {
            List<Lab> listLessons = new List<Lab>() { new Lab() { building = "F", number = 200, CourseId = c1.Object.ID, Day = "Sunday", LCourseID = c3.Object.ID, Start = 10, End = 14, projector = true, practitionerID = lec.Object.ID, LTeacherID = lec.Object.ID, NumStudent = 10 },
            new Lab() { building = "M", number = 102, CourseId = c1.Object.ID, Day = "Monday", LCourseID = c2.Object.ID, Start = 16, End = 18, projector = true, practitionerID = lec.Object.ID, LTeacherID = lec.Object.ID, NumStudent = 10 },
            new Lab() { building = "S", number = 101, CourseId = c1.Object.ID, Day = "Friday", LCourseID = c1.Object.ID, Start = 12, End = 13, projector = true, practitionerID = lec.Object.ID, LTeacherID = lec.Object.ID, NumStudent = 10 }};

            prac.Setup(x => x.LessonLabs).Returns(listLessons);
        }
        private void initLessonPractise()
        {
            List<Practise> listLessons = new List<Practise>() { new Practise() { building = "F", number = 200, CourseId = c1.Object.ID, Day = "Monday", LCourseID = c3.Object.ID, Start = 10, End = 12, projector = true, practitionerID = lec.Object.ID, LTeacherID = lec.Object.ID, NumStudent = 10 },
            new Practise() { building = "M", number = 102, CourseId = c1.Object.ID, Day = "Friday", LCourseID = c2.Object.ID, Start = 16, End = 18, projector = true, practitionerID = lec.Object.ID, LTeacherID = lec.Object.ID, NumStudent = 10 },
            new Practise() { building = "S", number = 101, CourseId = c1.Object.ID, Day = "Sunday", LCourseID = c1.Object.ID, Start = 17, End = 19, projector = true, practitionerID = lec.Object.ID, LTeacherID = lec.Object.ID, NumStudent = 10 },
            new Practise() { building = "A", number = 103, CourseId = c1.Object.ID, Day = "Sunday", LCourseID = c3.Object.ID, Start = 15, End = 17, projector = true, practitionerID = lec.Object.ID, LTeacherID = lec.Object.ID, NumStudent = 10 }};

            prac.Setup(x => x.LessonPractises).Returns(listLessons);
        }
        private void initLessonStudent()
        {
            List<StudentsRegisterToLessonLectures> listLessonsStudent = new List<StudentsRegisterToLessonLectures>() { new StudentsRegisterToLessonLectures() { CourseID = c1.Object.ID, LessonDay = "Suday", LessonStart = 10, LessonEnd = 14, StudentId = std.Object.ID, lectureID = lec.Object.ID },
            new StudentsRegisterToLessonLectures() { CourseID = c1.Object.ID, LessonDay = "Monday", LessonStart = 10, LessonEnd = 11, StudentId = std.Object.ID, lectureID = lec.Object.ID },
            new StudentsRegisterToLessonLectures() { CourseID = c1.Object.ID, LessonDay = "Monday", LessonStart = 10, LessonEnd = 18, StudentId = std.Object.ID, lectureID = lec.Object.ID } };
            std.Setup(x => x.RegisteredLessonLectures).Returns(listLessonsStudent);

            // set init also practises and lab like that way
        }


        [TestMethod()]
        public void CapitalizeFirstLetterEachWordTest1()
        {
            string s1 = GeneralFuntion.CapitalizeFirstLetterEachWord("hadriel benjo");
            string s2 = "Hadriel Benjo";
            Assert.AreEqual(s1, s2, false, CultureInfo.CurrentCulture);
        }

        [TestMethod()]
        public void thisLesson1NotConflitWithLesson2Test1()
        {
            Assert.IsTrue(GeneralFuntion.thisLesson1NotConflitWithLesson2(11, 16, 16, 19));
        }

        [TestMethod()]
        public void validAgeTest()
        {
            int age = 27;
            Assert.IsTrue(GeneralFuntion.validAge(age));
        }

        [TestMethod()]
        public void ValidPhoneTest()
        {
            string sphone = "050-000-0000";
            Assert.IsTrue(GeneralFuntion.ValidPhone(sphone));
        }

        [TestMethod()]
        public void formatTimeTest()
        {
            Assert.AreEqual("08:00", GeneralFuntion.formatTime(8), false, CultureInfo.CurrentCulture);
        }

        [TestMethod()]
        public void thisLesson1NotConflitWithLesson2Test()
        {
            DateTime s1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
            DateTime e1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            DateTime s2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            DateTime e2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0);
            Assert.IsTrue(GeneralFuntion.thisLesson1NotConflitWithLesson2(s1, e1, s2, e2));
        }

        [TestMethod()]
        public void convertToDateTimeTest()
        {
            DateTime a = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0);
            Assert.IsTrue(GeneralFuntion.compareCompleteDateFromDateTime(a, GeneralFuntion.convertToDateTime(15)));
        }

        [TestMethod()]
        public void compareTimeFromDateTimeTest()
        {
            DateTime a = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            DateTime b = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 17, 0, 0);
            Assert.IsTrue(GeneralFuntion.compareTimeFromDateTime(a, b));
        }

        [TestMethod()]
        public void compareDateFromDateTimeTest()
        {
            DateTime a = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 5, 0, 0);
            DateTime b = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 0, 0);
            Assert.IsTrue(GeneralFuntion.compareDateFromDateTime(a, b));
        }

        [TestMethod()]
        public void compareCompleteDateFromDateTimeTest()
        {
            DateTime a = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 6, 0);
            DateTime b = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 6, 0);
            Assert.IsTrue(GeneralFuntion.compareCompleteDateFromDateTime(a, b));
        }

        [TestMethod()]
        public void ConvertStringToDateTest()
        {
            DateTime a = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0);
            Assert.IsNotNull(GeneralFuntion.ConvertStringToDate("15:00"));
        }

        [TestMethod()]
        public void getAgeFromStringDateTest()
        {
            string strdate = "10.10.1990";
            int age = 27;
            Assert.IsTrue(age == GeneralFuntion.getAgeFromStringDate(strdate));
        }

        [TestMethod()]
        public void getAgeFromDateTest()
        {
            DateTime a = new DateTime(1990, 10, 29, 0, 0, 0);
            int age = 27;
            Assert.IsTrue(age == GeneralFuntion.getAgeFromDate(a));
        }

        [TestMethod()]
        public void checkIfEmailValidTest()
        {
            string email = "Ronen@sce.ac.il";
            Assert.IsTrue(GeneralFuntion.checkIfEmailValid(email));
        }


        [TestMethod()]
        public void studentHasPassCourseTest()
        {
            initMocks();
            Assert.IsTrue(GeneralFuntion.studentHasPassCourse(std.Object, c2.Object));
        }

        [TestMethod()]
        public void averageOfStudentOfHisCoursesTest()
        {
            initMocks();
            Assert.AreEqual(80, GeneralFuntion.averageOfStudentOfHisCourses(std.Object));
        }

        [TestMethod()]
        public void getGradeOfCourseofStudentTest()
        {
            initMocks();
            Assert.AreEqual(70, GeneralFuntion.getGradeOfCourseofStudent(std.Object, c3.Object));
        }

        [TestMethod()]
        public void getAmountOfCourseofStudentTest()
        {
            initMocks();
            Assert.AreEqual(3, GeneralFuntion.getAmountOfCourseofStudent(std.Object));
        }

        [TestMethod()]
        public void getAmountOfCourseofLecturerTest()
        {
            initMocks();
            Assert.AreEqual(3, GeneralFuntion.getAmountOfCourseofLecturer(lec.Object));
        }

        [TestMethod()]
        public void getAmountOfCourseofPractitionerTest()
        {
            initMocks();
            Assert.AreEqual(3, GeneralFuntion.getAmountOfCourseofPractitioner(prac.Object));
        }

        [TestMethod()]
        public void getAmountOfApprovedCourseofLecturerTest()
        {
            initMocks();
            Assert.AreEqual(2, GeneralFuntion.getAmountOfApprovedCourseofLecturer(lec.Object));
        }

        [TestMethod()]
        public void getAmountOfApprovedCourseofPractitionerTest()
        {
            initMocks();
            Assert.AreEqual(1, GeneralFuntion.getAmountOfApprovedCourseofPractitioner(prac.Object));
        }

        [TestMethod()]
        public void removeCourseFromPractitionerTest()
        {
            initMocks();
            Assert.IsTrue(GeneralFuntion.removeCourseFromPractitioner(prac.Object, c3.Object));
        }

        [TestMethod()]
        public void removeCourseFromLecturerTest()
        {
            initMocks();
            Assert.IsTrue(GeneralFuntion.removeCourseFromLecturer(lec.Object, c3.Object));
        }

        [TestMethod()]
        public void AddCourseToLecturerTest()
        {
            initMocks();
            Assert.IsTrue(GeneralFuntion.AddCourseToLecturer(lec.Object, c4.Object));
        }

        [TestMethod()]
        public void AddCourseToPractitionerTest()
        {
            initMocks();
            Assert.IsTrue(GeneralFuntion.AddCourseToPractitioner(prac.Object, c4.Object));
        }

        [TestMethod()]
        public void AddCourseToStudentTest()
        {
            initMocks();
            Assert.IsTrue(GeneralFuntion.AddCourseToStudent(std.Object, c4.Object));
        }

        [TestMethod()]
        public void removeCourseFromStudentTest()
        {
            initMocks();
            Assert.IsTrue(GeneralFuntion.removeCourseFromStudent(std.Object, c1.Object));
        }

        [TestMethod()]
        public void isOutstandStudentTest()
        {
            initMocks();
            std.Object.Enrollments.Add(new Enrollment { CourseId = c4.Object.ID, StudentId = std.Object.ID, Grade = 100 });
            Assert.IsTrue(GeneralFuntion.isOutstandStudent(std.Object));
        }

        [TestMethod()]
        public void getAmountOfLecturesOfLecturerTest()
        {
            initMocks();
            Assert.AreEqual(4, GeneralFuntion.getAmountOfLecturesOfLecturer(lec.Object));
        }

        [TestMethod()]
        public void getAmountOfLabsOfPractitionerTest()
        {
            initMocks();
            Assert.AreEqual(3, GeneralFuntion.getAmountOfLabsOfPractitioner(prac.Object));
        }

        [TestMethod()]
        public void getAmountOfPractisesOfPractitionerTest()
        {
            initMocks();
            Assert.AreEqual(4, GeneralFuntion.getAmountOfPractisesOfPractitioner(prac.Object));
        }

        [TestMethod()]
        public void getAmountOfLessonsOfPractitionerTest()
        {
            initMocks();
            Assert.AreEqual(7, GeneralFuntion.getAmountOfLessonsOfPractitioner(prac.Object));
        }

        [TestMethod()]
        public void getTotalHourOfAllLessonOfLecturerTest()
        {
            initMocks();
            int h = GeneralFuntion.getTotalHourOfAllLessonOfLecturer(lec.Object);
            Assert.AreEqual(11, h);
        }

        [TestMethod()]
        public void LecturerHaveNoMore12WeeklyHoursLessonsTest()
        {
            initMocks();
            int h = GeneralFuntion.getTotalHourOfAllLessonOfLecturer(lec.Object);
            Assert.IsTrue(h <= 12);
        }

        [TestMethod()]
        public void getTotalHourOfAllLessonOfPractitionerTest()
        {
            initMocks();
            int h = GeneralFuntion.getTotalHourOfAllLessonOfPractitioner(prac.Object);
            Assert.AreEqual(15, h);
        }

        [TestMethod()]
        public void PractitionerHaveNoMore16WeeklyHoursLessonsTest()
        {
            initMocks();
            int h = GeneralFuntion.getTotalHourOfAllLessonOfPractitioner(prac.Object);
            Assert.IsTrue(h <= 16);
        }

        [TestMethod()]
        public void AllLessonsTimeDontClashOfLecturerTest()
        {
            initMocks();
            Assert.IsTrue(GeneralFuntion.AllLessonsTimeDontClashOfLecturer(lec.Object));
        }

        [TestMethod()]
        public void AllLessonsTimeDontClashOfPractitionerTest()
        {
            initMocks();
            Assert.IsTrue(GeneralFuntion.AllLessonsTimeDontClashOfPractitioner(prac.Object));
        }

        [TestMethod()]
        public void getAmountOfLessonsOfStudentTest()
        {
            initMocks();
            int les = GeneralFuntion.getAmountOfLessonsOfStudent(std.Object);
            Assert.AreEqual(3, les);
        }




        // =================================================================================================
                                                             // LUBA

            // ====================================================================
                                            // user unit tests

        private void initUser()
        {
            user1 = new Mock<User>();
            user1.Setup(x => x.ID).Returns(123);
            user1.Setup(x => x.email).Returns("user1@gmail.com");
            user1.Setup(x => x.password).Returns("000");
            user1.Setup(x => x.permission).Returns("Registrar");
        }

        [TestMethod()]
        public void checkUserID()
        {
            initMocks();
            initUser();
            int idTemp = 123;
            Assert.AreEqual(user1.Object.ID, idTemp);
        }


        [TestMethod()]
        public void checkUserEmail()
        {
            initMocks();
            initUser();
            string em = "user1@gmail.com";
            Assert.AreEqual(user1.Object.email, em);
        }

        [TestMethod()]
        public void checkUserPass()
        {
            initMocks();
            initUser();
            string pass = "000";
            Assert.AreEqual(user1.Object.password, pass);
        }

        [TestMethod()]
        public void checkUserPermission()
        {
            initMocks();
            initUser();
            string perm = "Registrar";
            Assert.AreEqual(user1.Object.permission, perm);
        }


        // ====================================================================
        // staff member unit tests

        private void initStaffMember()
        {
            staff1 = new Mock<StaffMember>();
            DateTime birth = new DateTime(1967, 01, 01, 15, 0, 0);
            staff1.Setup(x => x.Age).Returns(50);
            staff1.Setup(x => x.BirthDate).Returns(birth);
            staff1.Setup(x => x.Gender).Returns("Female");
            staff1.Setup(x => x.Phone).Returns("052-685-9786");
            staff1.Setup(x => x.Name).Returns("Shlomit");
        }

        [TestMethod()]
        public void checkStaffAge()
        {
            initMocks();
            initStaffMember();
            int ag = 50;
            Assert.AreEqual(staff1.Object.Age, ag);
        }

        [TestMethod()]
        public void checkStaffBirth()
        {
            initMocks();
            initStaffMember();
            DateTime birth = new DateTime(1967, 01, 01, 15, 0, 0);
            Assert.AreEqual(staff1.Object.BirthDate, birth);
        }

        [TestMethod()]
        public void checkStaffGender()
        {
            initMocks();
            initStaffMember();
            string gender = "Female";
            Assert.AreEqual(staff1.Object.Gender, gender);
        }

        [TestMethod()]
        public void checkStaffPhone()
        {
            initMocks();
            initStaffMember();
            string phone = "052-685-9786";
            Assert.AreEqual(staff1.Object.Phone, phone);
        }

        [TestMethod()]
        public void checkStaffName()
        {
            initMocks();
            initStaffMember();
            string nam = "Shlomit";
            Assert.AreEqual(staff1.Object.Name, nam);
        }

        // =========================================================================


    }
}

