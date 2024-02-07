Out.txt : main.exe Makefile
	mono $< one two three > $@

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean:
	$(RM) Out.txt main.exe