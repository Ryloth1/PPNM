CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^)) # macros
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

default: OutA.svg OutB.svg OutC.svg \
	outA.txt dataA.txt \
	outB.txt dataB.txt \
	outC.txt dataC.txt 

OutA.svg: outA.txt dataA.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "x";\
		set ylabel "y";\
		set size 1,1;\
		set key outside;\
                set term svg size 600, 800 ;\
                set multiplot layout 2,1 columns ;\
		set title "Linear interpolation";\
		plot "dataA.txt" with p pt 7 ps 0.5 title "Data"\
		,"$<" using 1:2 with l notitle;\
		set title "Integral of Linear interpolation";\
		plot "$<" using 1:3 with l notitle;\
		unset multiplot;\
		'|tee log.gpi | gnuplot

OutB.svg: outB.txt dataB.txt Makefile
	echo '\
                set terminal svg background "white" ;\
                set out "$@" ;\
                set xlabel "x";\
                set ylabel "y";\
		set size 1,1;\
                set term svg size 600, 1200 ;\
		set multiplot layout 3,1 columns;\
                set title "Quadratic spline";\
		plot "dataB.txt" using 1:2 with p pt 7 ps 0.5 title "Data"\
		,"dataB.txt" using 1:3 with p pt 7 ps 0.5 notitle \
                ,"dataB.txt" using 1:4 with p pt 7 ps 0.5 notitle \
		,"$<" using 1:2 with l notitle linecolor rgb "#4627E2"\
                ,"$<" using 1:3 with l notitle linecolor rgb "#27E23A"\
                ,"$<" using 1:4 with l notitle linecolor rgb "#F0860C";\
		set title "Quadratic spline derivatives";\
                plot "$<" using 1:5 with l notitle linecolor rgb "#4627E2"\
                ,"$<" using 1:6 with l notitle linecolor rgb "#27E23A"\
                ,"$<" using 1:7 with l notitle linecolor rgb "#F0860C";\
		set title "Quadratic spline integrals";\
		plot "$<" using 1:8 with l notitle linecolor rgb "#4627E2"\
                ,"$<" using 1:9 with l notitle linecolor rgb "#27E23A"\
		,"$<" using 1:10 with l notitle linecolor rgb "#F0860C";;\
		unset multiplot;\
                '|tee log.gpi | gnuplot

OutC.svg: outC.txt dataC.txt Makefile
	echo '\
                set terminal svg background "white" ;\
                set out "$@" ;\
                set xlabel "x";\
                set ylabel "y";\
		set size 1,1;\
		set key outside;\
		set term svg size 600, 1200 ;\
                set multiplot layout 3,1 columns ;\
                set title "Cubic spline";\
                plot "dataC.txt" with p pt 7 ps 0.5 title "Data"\
		,"" smooth csplines t "gnuplot spline"\
                ,"$<" using 1:2 with l title "Homemade spline";\
                set title "Cubic spline derivative";\
                plot "$<" using 1:3 with l notitle;\
		set title "Cubic spline integral";\
		plot "$<" using 1:4 with l notitle;\
                unset multiplot;\
                '|tee log.gpi | gnuplot

outA.txt: mainA.exe
	mono $< 1> $@ 2> dataA.txt

outB.txt: mainB.exe
	mono $< -output:dataB.txt 2> $@ 1> OutBTest.txt

outC.txt: mainC.exe
	mono $< 1> $@ 2> dataC.txt

mainA.exe: mainA.cs extlib.dll; $(MKEXE)

mainB.exe: mainB.cs extlib.dll; $(MKEXE)

mainC.exe: mainC.cs extlib.dll; $(MKEXE)
	
extlib.dll: ../../lib/matrix.cs ../../lib/vector.cs\
       	../../lib/qrgs.cs ../../lib/linsol.cs \
	../../lib/genlist.cs ../../lib/spline.cs extlib.dll; $(MKLIB)

clean: 
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*