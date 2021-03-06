﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HOK.Buro.Formats;
using HOK.Buro.Properties;
using Rhino;
using Rhino.Geometry;
using Grasshopper.Kernel;

using HOK.Buro.Logic;

namespace HOK.Buro.Components.Debug
{
    public class ReadProgramPackage : GH_Component
    {
        public ReadProgramPackage() : base("Read Program Package", "ReadProgram", "Outputs program package information.", Resources.TabName, Resources.Category_Debug)
        {

        }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Program Package", "<P>", "Program package data.", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Distribution", "D", "Percent coverage of floor plan area alotted.", GH_ParamAccess.item);
            pManager.AddGeometryParameter("Boundary", "B", "Rectangular bounds of program occupation.", GH_ParamAccess.item);
            pManager.AddGeometryParameter("Drawing Geometry", "G", "Curve information for 2D representation of program.", GH_ParamAccess.list);
            pManager.AddIntegerParameter("Program Quota", "Q", "Initial quota for program.", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            ProgramPackage program = null;

            if (!DA.GetData(0, ref program))
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Unable to read program input.");
                return;
            }

            DA.SetData(0, program.Distribution);
            DA.SetData(1, program.OccupationBoundary);
            DA.SetDataList(2, program.DrawingGeometry);
            DA.SetData(3, program.Quota);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Resources.buro_read_program;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("f27d4ede-638a-4469-9257-2d7b932d3c21"); }
        }
    }
}
