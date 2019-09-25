namespace InstructorsListApp.Models {
    public class Error {
        public static int EntryIsNotFound = 0x0;
        public static int PostBodyIsNotValid = 0x1;

        public int errCode {get; set;}
        public string errText {get; set;}

        public Error(int errCode, string errText) {
            this.errCode = errCode;
            this.errText = errText;
        }
    }
}