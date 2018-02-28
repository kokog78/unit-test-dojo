package dojo;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

public class Parser {

	public String[] parse(String input) {
		String[] result = new String[3];
		String current = "";
		boolean lookup = false;
		for (int i=0; i<input.length(); i++) {
			switch (input.charAt(i)) {
			case ' ':
			case '\t':
				lookup = !current.isEmpty();
				break;
			case '\n':
			case '\r':
				lookup = current.length()>0;
				break;
			default:
				lookup = false;
				current += input.charAt(i);
			}
			if (lookup) {
				update(result, current);
				current = "";
				lookup = false;
			}
		}
		if (!current.isEmpty()) {
			update(result, current);
		}
		return result;
	}
	
	private void update(String[] array, String part) {
		int what = lookup(part);
		switch (what) {
		case 2:
			if (array[2]==null) {
				array[2] = "";
			}
			if (array[2].length()>0) {
				array[2] += " ";
			}
			array[2] += part;
			break;
		case 0:
			if (array[0]==null) {
				array[0] = part;
			} else {
				if (array[2]==null) {
					array[2] = "";
				}
				if (array[2].length()>0) {
					array[2] += " ";
				}
				array[2] += part;
			}
			break;
		case 1:
			if (array[1]==null) {
				array[1] = part;
			} else {
				if (array[2]==null) {
					array[2] = "";
				}
				if (array[2].length()>0) {
					array[2] += " ";
				}
				array[2] += part;
			}
			break;
		}
	}
	
	private int lookup(String part) {
		if (part==null) {
			return -1;
		}
		boolean ok = true;
		for (int i=0; i<part.length(); i++) {
			switch (part.charAt(i)) {
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				break;
			default:
				ok = false;
			}
		}
		if (ok && part.length()==4) {
			return 0;
		}
		try {
			if (isThere(part)) {
				return 1;
			}
		} catch (IOException ex) {
			return 2;
		}
		return 2;
	}
	
	private boolean isThere(String part) throws IOException {
		String path = "parser.txt";
		InputStream stream = getClass().getResourceAsStream(path);
		if (stream!=null) {
			boolean ok = false;
			BufferedReader reader = new BufferedReader(new InputStreamReader(stream, "UTF-8"));
			String line;
			while ((line = reader.readLine())!=null) {
				if (line.equals(part)) {
					ok = true;
				}
			}
			stream.close();
			return ok;
		} else {
			return false;
		}
	}
	
}
