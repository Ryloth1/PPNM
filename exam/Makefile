CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^)) # macros
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
TIME = time --output=$@ --append --format "$$N %e %U"

default: OutA.txt OutB.txt OutB.fit.svg


OutB.fit.svg: data.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@";\
		set xlabel "t (days)" ;\
		set ylabel "Activity" ;\
		set grid;\
		set title "exponential fit of radioactive decay of 224Ra";\
		f(x) = a*exp(-b*x) ;\
		a = 142.403540630783; b = 0.171;\
		plot "$<" with errorbars title "data"\
		,f(x) title sprintf("fit: %.f*e^{-%.2f t}",a,b)\
		'|tee log.gpi | gnuplot


OutA.txt: mainA.exe
	mono $< > $@

OutB.txt: mainB.exe
	mono $< -input:data.txt > $@


mainA.exe: mainA.cs extlib.dll; $(MKEXE)

mainB.exe: mainB.cs extlib.dll; $(MKEXE)


extlib.dll: ../lib/matrix.cs ../lib/vector.cs ../lib/jacobi.cs \
	../lib/genlist.cs ../lib/qrgs.cs ../lib/ls.cs; $(MKLIB)

clean: 
	$(RM) *.dll *.exe [Oo]ut* [Ll]og* *.[Ll]og