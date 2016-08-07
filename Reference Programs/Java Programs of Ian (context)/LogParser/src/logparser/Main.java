/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package logparser;

import java.io.File;

/**
 *
 * @author cortlim
 */
public class Main {
    
    public static void main(String[] args) {
    File folder = new File("C:/Users/Ms JAY/Desktop/Student Data (aplusix)/Reggy/D-2011-02-28/A-15-37-22-Entrainement/");
    File[] listOfFiles = folder.listFiles();

    for (int i = 0; i < listOfFiles.length; i++) {
      if (listOfFiles[i].isFile()) {
        System.out.println("File " + listOfFiles[i].getName());
      } else if (listOfFiles[i].isDirectory()) {
        System.out.println("Directory " + listOfFiles[i].getName());
      }
    }
    }
}
