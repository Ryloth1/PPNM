default: Out-stdio.txt out.txt

Out-stdio.txt : stdio.exe input Makefile
	mono $< <input 1>$@ 2>log-stdio.txt
	echo "\n" >> $@
	cat input | mono $< 1>>$@ 2>>log-stdio.txt

stdio.exe: stdio.cs
	mcs -target:exe -out:$@ $<

cmdline.exe :cmdline.cs	
	mcs -target:exe -out:$@ $<

Out.txt :cmdline.exe input.txt
	mono cmdline.exe -input:input.txt -output:$@ -numbers:2,3.45,6

clean:
	$(RM) Out.txt main.exe stdio.exe Out-stdio.txt input.txt log-stdio.txt cmdline.exe