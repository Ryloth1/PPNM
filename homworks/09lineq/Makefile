CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:./$@ $(LIBS) $(CODE)
TIME = time --output=$@ --append --format "$$N %e %U" 

default: OutAB.txt Out.times.svg Makefile

Out.times.svg: outtimes.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "Matrix size N";\
		set ylabel "Decomposition time";\
		set title "Running time as function of matrix size";\
		f(x)=b+(x/a)**c;\
		b=1; a=90; c=3;\
		fit f(x) "$<" via a,b;\
		plot "$<" with lp \
		,f(x) title sprintf("fit: (n/%.f)^{%.2f}+%.3f",a,c,b) \
		'|tee log.gpi |gnuplot

outtimes.txt: time.exe Makefile
	>$@
	for N in $$(seq 100 25 600); do \
		$(TIME) mono $< -msize:$$N 1>out 2>err ;\
	done ; wait

OutAB.txt: mainAB.exe
	mono $< > $@

time.exe: time.cs extlib.dll; $(MKEXE)

extlib.dll : ../../lib/matrix.cs ../../lib/vector.cs ../../lib/qrgs.cs; $(MKLIB)


mainAB.exe : mainAB.cs extlib.dll; $(MKEXE)

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og* *.[Ll]og
