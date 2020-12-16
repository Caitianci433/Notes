package com.hyron.caitianci;

public class TestJava01 {

    public static class TestThread01 implements Runnable{
        @Override
        public void run(){
            for(int i=0;i<=10;i++){
                System.out.println(Thread.currentThread().getName()+"time pass -->"+i);
            }
            System.out.println("return!");
            return;
        }
    }

    public static  class TestThread02 extends Thread{
        @Override
        public void run() {
            for(int i=0;i<=10;i++){
                System.out.println(Thread.currentThread().getName()+"time pass -->"+i);
            }
            System.out.println("return!");
            return;
        }
    }




    public static void main(String[] args )
    {
        Object a = new Object();
        System.out.println(Thread.currentThread().getName());
        System.out.println(Thread.currentThread().getState());
        System.out.println(Thread.currentThread().getPriority());
        new Thread(new TestThread01(),"t1").start();
        TestThread02 t = new TestThread02();
        t.start();



    }


}

