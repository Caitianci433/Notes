package com.hyron.caitianci;

import java.io.*;

public class TestIO02 {
    public static void main(String[] args) throws IOException {
        InputStream is =null;
        OutputStream os = null;
        try {
            // 在try()中打开文件会在结尾自动关闭
            is = new FileInputStream("C:\\Users\\caitianci\\Desktop\\FileInputStreamTest.txt");
            os = new FileOutputStream("C:\\Users\\caitianci\\Desktop\\FileOutputStreamTest.txt");
            byte[] buf = new byte[4];
            int hasRead = 0;
            while ((hasRead = is.read(buf)) > 0) {
                os.write(buf, 0, hasRead);
            }
            System.out.println("write success");
        } catch (Exception e) {
            e.printStackTrace();
        }finally{
            os.close();
            is.close();
        }
    }
}
