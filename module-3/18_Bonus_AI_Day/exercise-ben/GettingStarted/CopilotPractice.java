
public class CopilotPractice {
    private String[] studentNames;

    public CopilotPractice(String[] studentNames) {
        this.studentNames = studentNames;
    }

    public String[] getStudentNames() {
        return studentNames;
    }

    public void setStudentNames(String[] studentNames) {
        this.studentNames = studentNames;
    }

    // Check if a student name is in the array
   public boolean hasStudent(String name) {
        for (String student : studentNames) {
            if (student.equalsIgnoreCase(name)) {
                return true;
            }
        }
        return false;
}
}
