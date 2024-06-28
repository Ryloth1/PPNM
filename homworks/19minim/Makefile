CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^)) # macros
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

default: OutA.txt OutB.svg outB.txt OutC.txt 

OutB.svg: datahiggs.txt outB.txt Makefile
	echo '\
                set terminal svg background "white" ;\
                set out "$@" ;\
                set xlabel "E [GeV]";\
                set ylabel "{/symbol s} (background subtracted)";\
		set title "Higgs particle resonance fit with newton method";\
		set grid;\
                plot "$<" with errorbars t "Data"\
		, "outB.txt" with l t "Breit-Wigner fit"\
                '|tee logB.gpi | gnuplot

OutA.txt: mainA.exe
	mono $< > $@

outB.txt: mainB.exe
	mono $< < datahiggs.txt 1> $@ 2> logBhiggs.txt

OutC.txt: mainC.exe
	mono $< > $@

mainA.exe: mainA.cs extlib.dll; $(MKEXE)

mainB.exe: mainB.cs extlib.dll; $(MKEXE)

mainC.exe: mainC.cs extlib.dll; $(MKEXE)

extlib.dll: ../../lib/matrix.cs ../../lib/vector.cs \
	../../lib/genlist.cs ../../lib/qrgs.cs ../../lib/min.cs; $(MKLIB)

clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*