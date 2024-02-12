default : Out1.txt Out2.txt Out3.txt

Out1.txt : main1.exe 
	mono $< -numbers:1,2,3,4,5 >$@

Out2.txt : main2.exe input
	mono $< <input 2>$@

Out3.txt : main3.exe input.txt
	mono $< -input:input.txt -output:$@

main1.exe : main1.cs
	mcs -target:exe -out:$@ $<

main2.exe : main2.cs
	mcs -target:exe -out:$@ $<

main3.exe : main3.cs
	mcs -target:exe -out:$@ $<

clean:
	$(RM) main1.exe main2.exe main3.exe Out1.txt Out2.txt Out3.txt
