using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Substrate;
using Substrate.Nbt;

namespace Mystclean
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string searchWorldPath(string root)
        {
            if (/*root.EndsWith("world", StringComparison.InvariantCultureIgnoreCase) && */File.Exists(Path.Combine(root, "level.dat")))
                return root;

            string[] subdirs = Directory.GetDirectories(root);
            foreach (string subdir in subdirs)
            {
                string worldpath = searchWorldPath(subdir);
                if (worldpath != null)
                    return worldpath;
            }

            return null;
        }

        class Age
        {
            public string Name;
            public int Dimension;

            public override bool Equals(object obj)
            {
                Age o = obj as Age;
                if (obj == null)
                    return false;

                if (Name != o.Name)
                    return false;

                if (Dimension != o.Dimension)
                    return false;

                return true;
            }
        }

        void checkItem(Item item, List<Age> referencedAges, string owner, DimensionReference.ReferenceType type, int sourceDim, Vector3 sourceCoord)
        {
            if (item == null)
                return;

            checkItem(item.Source, referencedAges, owner, type, sourceDim, sourceCoord);
        }

        void checkItem(TagNodeCompound source, List<Age> referencedAges, string owner, DimensionReference.ReferenceType type, int sourceDim, Vector3 sourceCoord)
        {
            if (source == null)
                return;

            // inventory?
            if (source.ContainsKey("Items"))
            {
                TagNodeList items = source["Items"] as TagNodeList;
                if (items == null)
                    return;

                foreach (TagNodeCompound item in items)
                {
                    if (item == null)
                        continue;

                    checkItem(item, referencedAges, owner, type, sourceDim, sourceCoord);
                }
            }

            if (!source.ContainsKey("tag"))
                return;

            TagNodeCompound tag = source["tag"] as TagNodeCompound;
            if (tag == null || !tag.ContainsKey("agename"))
                return;

            Age age = new Age();
            age.Name = tag["agename"].ToTagString().Data;
            age.Dimension = tag["Dimension"].ToTagInt().Data;

            // ignore books to overworld, nether, or end-  we're not going to delete those dimensions..
            if (age.Dimension == -1 || age.Dimension == 0 || age.Dimension == 1)
                return;

            DimensionReference dr = new DimensionReference();
            dr.Type = type;
            dr.Owner = owner;
            dr.Dimension = sourceDim;
            dr.Coords = sourceCoord;

            msg("Found " + type.ToString() + " reference to Mystcraft age \"" + age.Name + "\" (#" + age.Dimension.ToString() + ")");

            if (!referencedAges.Contains(age))
            {
                referencedAges.Add(age);

                // check the dimensionlist item so we keep it
                for (int x = 0; x < agesDelete.Items.Count; x++)
                {
                    DimensionEntry de = agesDelete.Items[x] as DimensionEntry;
                    if (de.Dimension == age.Dimension)
                    {
                        de.Name = age.Name;
                        de.References.Add(dr);
                        agesDelete.Items.RemoveAt(x);
                        agesKeep.TopIndex = agesKeep.Items.Add(de);
                        agesKeep.Update();
                        updateKeepSize();
                        updateDeleteSize();
                        agesDelete.Update();
                        System.Threading.Thread.Sleep(350);
                        agesKeep.Update();
                        System.Threading.Thread.Sleep(350);
                        break;
                    }
                }
            }
            else
            {
                for (int x = 0; x < agesKeep.Items.Count; x++)
                {
                    DimensionEntry de = agesKeep.Items[x] as DimensionEntry;
                    if (de.Dimension == age.Dimension)
                    {
                        de.References.Add(dr);
                        break;
                    }
                }
            }
        }

        bool shouldScanChunk(ChunkRef chunk, int blocksFromOrigin)
        {
            if (blocksFromOrigin == -1)
                return true;

            int vx = (chunk.X * 16) - originX;
            int vz = (chunk.Z * 16) - originZ;
            int dist = (int)Math.Sqrt((double)(vx * vx + vz * vz));
            if (dist > blocksFromOrigin)
                return false;

            return true;
        }

        bool parseDualInt(string str, out int a, out int b)
        {
            a = -1;
            b = -1;
            string tmp = string.Empty;
            for (int x = 0; x < str.Length+1; x++)
            {
                char c = (x < str.Length ? str[x] : (char)0);

                if (char.IsDigit(c) || (string.IsNullOrEmpty(tmp) && c == '-'))
                    tmp += c;
                else if(!string.IsNullOrEmpty(tmp))
                {
                    if (a == -1)
                    {
                        if (!int.TryParse(tmp, out a))
                            a = -1;
                    }
                    else if (b == -1)
                    {
                        if (!int.TryParse(tmp, out b))
                            b = -1;
                    }
                    else
                        break;
                    tmp = string.Empty;
                }
            }

            return (a != -1 && b != -1);
        }

        int originX, originZ;

        class PlayerListEntry
        {
            public string Player;
            public int X;
            public int Z;

            public override string ToString()
            {
                return Player + " (" + X.ToString() + ", " + Z.ToString() + ")";
            }
        }

        class DimensionReference
        {
            public enum ReferenceType
            {
                Player,
                Entity,
                Block
            }

            public ReferenceType Type;
            public string Owner;
            public int Dimension;
            public Vector3 Coords;

            public override string ToString()
            {
                return Type.ToString()[0] + ": " + Owner + " (#" + Dimension.ToString() + ": " + ((int)Coords.X).ToString() + "," + ((int)Coords.Y).ToString() + "," + ((int)Coords.Z).ToString() + ")";
            }
        }

        class DimensionEntry
        {
            public string Path;
            public string Name;
            public int Dimension;
            public long SizeOnDisk;
            public List<DimensionReference> References = new List<DimensionReference>();

            public override string ToString()
            {
                return Name + " (" + (SizeOnDisk / 1024 / 1024).ToString() + "mb)";
            }
        }

        long folderSize(string path)
        {
            long total = 0;
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fis = di.GetFiles("*.*", SearchOption.AllDirectories);
            foreach(FileInfo fi in fis)
                total += fi.Length;
            return total;
        }

        string worldPath = null;

        bool scanning = false;
        bool cancel = false;
        private void scanWorld_Click(object sender, EventArgs e)
        {
            if (scanning == true)
            {
                cancel = true;
                scanWorld.Enabled = false;
                status("CANCEL");
                return;
            }

            if (worldGroup.Enabled)
            {
                if (MessageBox.Show("Starting a new scan will clear the existing results.\n\nStart new scan?", "New Scan", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.OK)
                    return;
            }

            try
            {
                scanning = true;

                settings.Enabled = false;
                scanWorld.Enabled = false;
                toolStrip1.Update();

                worldPath = null;

                if (settingsForm.rememberWorld.Checked && Directory.Exists(settingsForm.LastWorldPath))
                    worldPath = searchWorldPath(settingsForm.LastWorldPath);

                if (worldPath == null)
                {
                    status("CHOOSE");

                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.Description = "Find your server or world folder";
                    fbd.ShowNewFolderButton = false;
                    //fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                    if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        return;

                    worldPath = searchWorldPath(fbd.SelectedPath);
                    if (worldPath == null)
                    {
                        msg("Could not locate world folder containing level.dat!");
                        return;
                    }

                    // update INI now in case we'll want to remember world
                    settingsForm.LastWorldPath = worldPath;
                    settingsForm.Save();
                }

                msgList.Items.Clear();
                agesKeep.Items.Clear();
                agesDelete.Items.Clear();
                updateDeleteSize();
                updateKeepSize();
                updateSelectedAgeInfo();

                cleanWorld.Enabled = false;
                worldGroup.Enabled = false;


                scanWorld.Enabled = true;
                scanWorld.Text = "Cancel";
                scanWorld.Image = global::Mystclean.Properties.Resources.cancel;
                toolStrip1.Update();


                status("IDENTIFY");
                string[] worldsubdirs = Directory.GetDirectories(worldPath);
                string sdprefix = "DIM_MYST";
                foreach (string _sd in worldsubdirs)
                {
                    string sd = Path.GetFileName(_sd);
                    if (!sd.StartsWith(sdprefix, StringComparison.InvariantCultureIgnoreCase))
                        continue;

                    int dim = int.Parse(sd.Substring(sdprefix.Length));

                    DimensionEntry de = new DimensionEntry();
                    de.Path = _sd;
                    de.Name = "Unknown";
                    de.Dimension = dim;
                    de.SizeOnDisk = folderSize(_sd);

                    agesDelete.Items.Add(de);
                }


                status("SCAN");
                msg("Starting scan: " + worldPath);

                NbtWorld world = null;

                // minecraft might be running-  try for a few seconds to see if we can snag it
                for(int x=0; x<10; x++)
                {
                    try
                    {
                        world = NbtWorld.Open(worldPath);
                        break;
                    }
                    catch (Exception)
                    {

                    }

                    System.Threading.Thread.Sleep(350);
                }
                if (world == null)
                {
                    msg("Couldn't access world-  minecraft running?");
                    return;
                }

                PlayerManager players = world.GetPlayerManager() as PlayerManager;


                if (string.Equals(settingsForm.scanOrigin.Text, "player", StringComparison.InvariantCultureIgnoreCase))
                {
                    PlayerChooser pc = new PlayerChooser();

                    foreach (Player player in players)
                    {
                        PlayerListEntry ple = new PlayerListEntry();
                        ple.Player = player.Name;
                        ple.X = (int)player.Position.X;
                        ple.Z = (int)player.Position.Z;
                        pc.players.Items.Add(ple);
                    }

                    PlayerListEntry chosenPlayer = null;

                    // if exactly 1 player, i think we know what to choose
                    if (pc.players.Items.Count == 1)
                        chosenPlayer = pc.players.Items[0] as PlayerListEntry;
                    else
                    {
                        if (pc.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                            return;

                        chosenPlayer = pc.players.SelectedItem as PlayerListEntry;
                    }

                    if (chosenPlayer != null)
                    {
                        originX = chosenPlayer.X;
                        originZ = chosenPlayer.Z;
                    }
                }
                else
                {
                    if (!parseDualInt(settingsForm.scanOrigin.Text, out originX, out originZ))
                    {
                        originX = 0;
                        originZ = 0;
                    }
                }


                List<Age> referencedAges = new List<Age>();

                if (players != null && settingsForm.scanPlayers.Checked)
                {
                    msg("Checking player inventories for linking books...");
                    foreach (Player player in players)
                    {
                        for (int x = 0; x < player.Items.Capacity; x++)
                        {
                            if (!player.Items.ItemExists(x))
                                continue;

                            checkItem(player.Items[x], referencedAges, player.Name, DimensionReference.ReferenceType.Player, player.Dimension, player.Position);
                        }
                    }
                }

                List<int> dimensionsToCheck = new List<int>();
                List<int> checkedDimensions = new List<int>();

                if(settingsForm.scanOverworld.Checked)
                    dimensionsToCheck.Add(0);

                if(settingsForm.scanNether.Checked)
                    dimensionsToCheck.Add(-1);

                if(settingsForm.scanEnd.Checked)
                    dimensionsToCheck.Add(1);

                if(settingsForm.scanTwilight.Checked)
                    dimensionsToCheck.Add(7);

                int blocksFromOrigin;
                if (!int.TryParse(settingsForm.blocksFromOrigin.Text, out blocksFromOrigin))
                    blocksFromOrigin = -1;

                int ya, yb;
                if (!parseDualInt(settingsForm.scanHeight.Text, out ya, out yb))
                {
                    ya = 0;
                    yb = 256;
                }
                int fromY = Math.Min(ya, yb);
                int toY = Math.Max(ya, yb);

                // searching referenced ages may add new references not found in player inventories or main worlds, so keep going until we completely exhaust the list
                while(dimensionsToCheck.Count > 0)
                {
                    if (settingsForm.scanAges.Checked)
                    {
                        // add any dimensions from referenced ages that we both haven't checked and don't yet plan to
                        foreach (Age age in referencedAges)
                            if (!dimensionsToCheck.Contains(age.Dimension) && !checkedDimensions.Contains(age.Dimension))
                                dimensionsToCheck.Add(age.Dimension);
                    }

                    // pop a candidate out and remember we will have already looked here
                    int dimension = dimensionsToCheck[0];
                    dimensionsToCheck.RemoveAt(0);
                    checkedDimensions.Add(dimension);

                    // try to grab chunk manager and check it-  could be this dimension doesn't exist
                    RegionChunkManager chunkman = world.GetChunkManager(dimension) as RegionChunkManager;
                    if(chunkman == null)
                    {
                        msg("Dimension #" + dimension.ToString() + " doesn't exist; skipping");
                        continue;
                    }

                    msg("Searching dimension #" + dimension.ToString() + " blocks" + (settingsForm.scanEntities.Checked ? " and entities" : string.Empty) + "...");

                    int minX = int.MaxValue;
                    int minZ = int.MaxValue;
                    int maxX = int.MinValue;
                    int maxZ = int.MinValue;
                    int numChunks = 0;
                    try
                    {
                        foreach (ChunkRef chunk in chunkman)
                        {
                            minX = Math.Min(minX, chunk.X);
                            minZ = Math.Min(minZ, chunk.Z);
                            maxX = Math.Max(maxX, chunk.X);
                            maxZ = Math.Max(maxZ, chunk.Z);

                            if (!shouldScanChunk(chunk, blocksFromOrigin))
                                continue;

                            numChunks++;
                        }
                    }
                    catch (Exception)
                    {
                        msg("ERROR scanning dimension #" + dimension.ToString() + ", skipping");
                        continue;
                    }

                    int chunksPerPixelX = (maxX - minX) / map.Width;
                    int chunksPerPixelZ = (maxZ - minZ) / map.Height;

                    Bitmap mapbmp = new Bitmap(Math.Min(map.Width, (maxX-minX)), Math.Min(map.Height, (maxZ-minZ)));
                    using (Graphics bmpg = Graphics.FromImage(mapbmp))
                        bmpg.Clear(Color.Black);


                    foreach (ChunkRef chunk in chunkman)
                    {
                        Point pt = new Point((chunk.X - minX) * mapbmp.Width / (maxX - minX), (chunk.Z - minZ) * mapbmp.Height / (maxZ - minZ));
                        if (pt.X < 0 || pt.X >= mapbmp.Width || pt.Y < 0 || pt.Y >= mapbmp.Height)
                            continue;

                        if (!shouldScanChunk(chunk, blocksFromOrigin))
                        {
                            mapbmp.SetPixel(pt.X, pt.Y, Color.Crimson);
                        }
                        else
                        {
                            mapbmp.SetPixel(pt.X, pt.Y, Color.DarkGoldenrod);
                        }
                    }

                    List<Point> chunkPts = new List<Point>();
                    List<Point> refPts = new List<Point>();

                    map.Image = mapbmp;
                    map.Update();

                    int checkedChunks = 0;
                    foreach (ChunkRef chunk in chunkman)
                    {
                        if (!shouldScanChunk(chunk, blocksFromOrigin))
                            continue;

                        int prevRefs = referencedAges.Count;

                        if (settingsForm.scanEntities.Checked)
                        {
                            foreach (Entity entity in chunk.Entities)
                            {
                                TagNode tn = entity.Source["id"];
                                if (tn == null || tn.ToTagString().Data != "Linkbook")
                                    continue;

                                TagNodeCompound item = entity.Source["Item"] as TagNodeCompound;
                                if (item == null)
                                    continue;

                                checkItem(item, referencedAges, tn.ToTagString().Data, DimensionReference.ReferenceType.Entity, dimension, entity.Position);
                            }
                        }

                        for (int y = fromY; y < toY; y++)
                            for(int z=0; z<chunk.Blocks.ZDim; z++)
                                for (int x = 0; x < chunk.Blocks.XDim; x++)
                                {
                                    AlphaBlock block = chunk.Blocks.GetBlock(x, y, z);

                                    TileEntity entity = block.GetTileEntity();
                                    if (entity == null)
                                        continue;

                                    Vector3 v = new Vector3();
                                    v.X = (double)(x + chunk.X*chunk.Blocks.XDim);
                                    v.Y = (double)y;
                                    v.Z = (double)(z + chunk.Z*chunk.Blocks.ZDim);
                                    checkItem(entity.Source, referencedAges, entity.ID, DimensionReference.ReferenceType.Block, dimension, v);
                                }

                        Point pt = new Point((chunk.X - minX) * mapbmp.Width / (maxX - minX), (chunk.Z - minZ) * mapbmp.Height / (maxZ - minZ));
                        if (referencedAges.Count > prevRefs)
                        {
                            if (!refPts.Contains(pt))
                                refPts.Add(pt);
                        }

                        if (!chunkPts.Contains(pt))
                            chunkPts.Add(pt);

                        checkedChunks++;
                        if ((checkedChunks % 100) == 0)
                        {
                            status(checkedChunks.ToString());
                            progressBar1.Value = checkedChunks * 100 / numChunks;

                            foreach (Point pt2 in chunkPts)
                                if (pt2.X >= 0 && pt2.X < mapbmp.Width && pt2.Y >= 0 && pt2.Y < mapbmp.Height)
                                    mapbmp.SetPixel(pt2.X, pt2.Y, Color.Yellow);

                            if (refPts.Count > 0)
                            {
                                using(Graphics g = Graphics.FromImage(mapbmp))
                                    foreach (Point pt2 in refPts)
                                    {
                                        g.FillEllipse(new SolidBrush(Color.Blue), new Rectangle(pt2.X - 2, pt2.Y - 2, 5, 5));
                                    }
                            }
                            chunkPts.Clear();
                            map.Invalidate();

                            Application.DoEvents();

                            if (cancel)
                                return;
                        }
                    }
                    msg("Finished dimension #" + dimension.ToString() + ", searched " + checkedChunks.ToString() + " chunks");
                }

                // done!
                msg("Scan finished!");
                worldGroup.Enabled = true;
                cleanWorld.Enabled = agesDelete.Items.Count > 0;
            }
            catch (Exception ex)
            {
                msg("Critical error during scan!");
                msg(ex.Message);
            }
            finally
            {
                scanWorld.Text = "Scan World";
                scanWorld.Enabled = true;
                settings.Enabled = true;
                scanWorld.Image = global::Mystclean.Properties.Resources.scanworld;
                status("READY");

                map.Image = null;
                progressBar1.Value = 0;

                scanning = false;
                cancel = false;
            }
        }

        void status(string s)
        {
            statusLabel.Text = s;
            statusLabel.Update();
        }

        void msg(string s)
        {
            msgList.TopIndex = msgList.Items.Add(s);
            msgList.Update();
        }

        Settings settingsForm = new Settings();

        private void settings_Click(object sender, EventArgs e)
        {
            try
            {
                settings.Enabled = false;   // prevents visual mouse hover glitch when re-enabling toolstrip
                toolStrip1.Enabled = false;
                toolStrip1.Update();

                settingsForm.ShowDialog();

            }
            catch (Exception)
            {

            }
            finally
            {
                settings.Enabled = true;
                toolStrip1.Enabled = true;
                toolStrip1.Update();
            }
        }

        private void tutorial_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=8fuJ6o4CPUs");
        }

        private void map_Paint(object sender, PaintEventArgs e)
        {
            if (map.Image == null)
                e.Graphics.FillRectangle(new HatchBrush(HatchStyle.ForwardDiagonal, Color.FromArgb(50, 50, 50), Color.Black), map.ClientRectangle);
        }

        void updateKeepSize()
        {
            long total = 0;
            foreach (DimensionEntry de in agesKeep.Items)
                total += de.SizeOnDisk;

            agesKeepLabel.Text = agesKeep.Items.Count.ToString() + " ages to keep (" + (total / 1024 / 1024).ToString() + "mb)";
            agesKeepLabel.Update();
        }

        void updateDeleteSize()
        {
            long total = 0;
            foreach (DimensionEntry de in agesDelete.Items)
                total += de.SizeOnDisk;

            agesDeleteLabel.Text = agesDelete.Items.Count.ToString() + " ages to delete (" + (total / 1024 / 1024).ToString() + "mb)";
            agesDeleteLabel.Update();
        }

        private void ageMoveToDelete_Click(object sender, EventArgs e)
        {
            DimensionEntry de = agesKeep.SelectedItem as DimensionEntry;
            if (de != null)
            {
                agesKeep.Items.Remove(de);
                agesDelete.TopIndex = agesDelete.Items.Add(de);
                updateKeepSize();
                updateDeleteSize();

                cleanWorld.Enabled = agesDelete.Items.Count > 0;
            }
        }

        private void ageMoveToKeep_Click(object sender, EventArgs e)
        {
            DimensionEntry de = agesDelete.SelectedItem as DimensionEntry;
            if (de != null)
            {
                agesDelete.Items.Remove(de);
                agesKeep.TopIndex = agesKeep.Items.Add(de);
                updateKeepSize();
                updateDeleteSize();

                cleanWorld.Enabled = agesDelete.Items.Count > 0;
            }
        }

        void updateSelectedAgeInfo()
        {
            DimensionEntry de = agesKeep.SelectedItem as DimensionEntry;
            if (de == null)
                de = agesDelete.SelectedItem as DimensionEntry;

            if (de == null)
            {
                selAgeName.Text = "";
                selAgeDimension.Text = "";
                selAgeSize.Text = "";
                selAgeReferences.Items.Clear();
                selAgePanel.Enabled = false;
            }
            else
            {
                selAgeName.Text = de.Name;
                selAgeDimension.Text = de.Dimension.ToString();
                selAgeSize.Text = (de.SizeOnDisk / 1024 / 1024).ToString() + "mb";
                selAgeReferences.BeginUpdate();
                selAgeReferences.Items.Clear();
                foreach (DimensionReference dr in de.References)
                    selAgeReferences.Items.Add(dr);
                selAgeReferences.EndUpdate();
                selAgePanel.Enabled = true;
            }
        }

        bool clearindex = false;
        private void agesKeep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clearindex)
                return;

            clearindex = true;
            agesDelete.SelectedIndex = -1;
            clearindex = false;
            updateSelectedAgeInfo();
        }

        private void agesDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clearindex)
                return;

            clearindex = true;
            agesKeep.SelectedIndex = -1;
            clearindex = false;
            updateSelectedAgeInfo();
        }

        private void cleanWorld_Click(object sender, EventArgs e)
        {
            if (agesDelete.Items.Count == 0)
                return;

            try
            {
                cleanWorld.Enabled = false;   // prevents visual mouse hover glitch when re-enabling toolstrip
                toolStrip1.Enabled = false;
                toolStrip1.Update();
                worldGroup.Enabled = false;
                worldGroup.Update();

                msgList.Items.Clear();
                msgList.Update();

                if (agesKeep.Items.Count == 0)
                {
                    if (MessageBox.Show("WARNING:  No ages are selected to be kept.\n\nEither you want to delete all ages, or this\nutility is not working to find references!\n\nAre you sure you want to delete ALL ages?", "Delete All Ages", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK)
                        return;
                }

                List<DimensionEntry> agesWithRefs = new List<DimensionEntry>();
                foreach (DimensionEntry de in agesDelete.Items)
                    if (de.References.Count > 0)
                        agesWithRefs.Add(de);

                if (agesWithRefs.Count > 0)
                {
                    string str = "WARNING:  The following age" + (agesWithRefs.Count > 1 ? "s are" : " is") + " in the delete list\nbut the world contains references to " + (agesWithRefs.Count > 1 ? "them" : "it") + ". If you\nproceed then " + (agesWithRefs.Count > 1 ? "these ages" : "this age") + " will be regenerated.\n\n";
                    foreach(DimensionEntry de in agesWithRefs)
                        str += "- #" + de.Dimension.ToString() + " " + de.Name + " (" + de.References.Count.ToString() + " reference" + (de.References.Count > 1 ? "s" : "") + ")\n";
                    str += "\nAre you sure you want to delete " + (agesWithRefs.Count > 1 ? "them" : "it") + "?";
                    if (MessageBox.Show(str, "Deleting Good Ages", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK)
                        return;
                }

                long total = 0;
                foreach(DimensionEntry de in agesDelete.Items)
                    total += de.SizeOnDisk;

                if (MessageBox.Show("You are about to purge " + (total / 1024 / 1024).ToString() + "mb (" + agesDelete.Items.Count.ToString() + " age" + (agesDelete.Items.Count > 1 ? "s" : "") + ").\nThis cannot be undone.\n\nProceed with cleanup?", "Confirm Cleanup", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
                    return;

                status("DELETE");

                int origCount = agesDelete.Items.Count;
                int cur = 0;
                while (agesDelete.Items.Count > 0)
                {
                    DimensionEntry de = agesDelete.Items[0] as DimensionEntry;
                    agesDelete.Items.RemoveAt(0);
                    agesDelete.Update();
                    updateDeleteSize();
                    if (de == null)
                        continue;

                    int finishedDelete = 0;
                    for (int x = 0; x < 10; x++)
                    {
                        try
                        {
                            Directory.Delete(de.Path, true);
                            msg("Deleted " + de.Path);
                            finishedDelete++;
                            break;
                        }
                        catch (Exception)
                        {

                        }
                        System.Threading.Thread.Sleep(200);
                    }
                    for (int x = 0; x < 10; x++)
                    {
                        try
                        {
                            string datapath = Path.Combine(worldPath, "data");
                            string agedata = Path.Combine(datapath, "agedata_" + de.Dimension.ToString() + ".dat");
                            if (File.Exists(agedata))
                            {
                                File.Delete(agedata);
                                msg("Deleted " + agedata);
                            }
                            finishedDelete++;
                            break;
                        }
                        catch (Exception)
                        {

                        }
                        System.Threading.Thread.Sleep(200);
                    }
                    if (finishedDelete < 2)
                    {
                        msg("Could not completely delete #" + de.Dimension.ToString() + " \"" + de.Name + "\"");
                    }

                    System.Threading.Thread.Sleep(50);

                    cur++;
                    progressBar1.Value = cur * 100 / origCount;
                    progressBar1.Update();
                }

                msg("Cleanup finished!");
            }
            catch (Exception ex)
            {
                msg("Critical error during cleanup!");
                msg(ex.Message);
            }
            finally
            {
                cleanWorld.Enabled = agesDelete.Items.Count > 0;
                toolStrip1.Enabled = true;
                toolStrip1.Update();
                worldGroup.Enabled = true;

                progressBar1.Value = 0;
                status("READY");
            }
        }
    }
}
