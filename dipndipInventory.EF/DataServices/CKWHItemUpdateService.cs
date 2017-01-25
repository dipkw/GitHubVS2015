using dipndipInventory.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace dipndipInventory.EF.DataServices
{
    public class CKWHItemUpdateService
    {
        DIPKWEntities _gpcontext;
        CKEntities _ckcontext;

        public int CKWHItemUpdate(int user_id)
        {
            try
            {
                _gpcontext = new DIPKWEntities();
                _ckcontext = new CKEntities();

                //DateTime last_update = (from ctable in _ckcontext.control_table where ctable.SourceTable == "ckwh_items" select ctable.LastLoadDate).FirstOrDefault();

                control_table ctbl = (from ctable in _ckcontext.control_table where ctable.SourceTable == "ckwh_items" select ctable).FirstOrDefault();

                DateTime last_update = ctbl.LastLoadDate;

                IEnumerable<VW_Item_QTY> gp_new_items = (from gpitem in _gpcontext.VW_Item_QTY where gpitem.CREATDDT >= last_update orderby gpitem.ITEMNMBR descending select gpitem);
                IEnumerable<VW_Item_QTY> gp_modified_items = (from gpitem in _gpcontext.VW_Item_QTY where gpitem.MODIFDT >= last_update orderby gpitem.ITEMNMBR descending select gpitem);


                foreach (VW_Item_QTY gp_item in gp_new_items)
                {
                    ckwh_items objNewWHItems = (from whitem in _ckcontext.ckwh_items where whitem.wh_item_code == gp_item.ITEMNMBR select whitem).SingleOrDefault();
                    if (objNewWHItems == null)
                    {
                        ckwh_items new_ckwh_item = new ckwh_items();
                        new_ckwh_item.wh_item_code = gp_item.ITEMNMBR;
                        new_ckwh_item.wh_item_description = gp_item.ITEMDESC;
                        new_ckwh_item.wh_category_description = gp_item.ITMCLSCD;
                        new_ckwh_item.wh_unit_description = gp_item.UOMSCHDL;
                        new_ckwh_item.quantity = gp_item.QTYAVBLE;
                        new_ckwh_item.unit_cost = gp_item.CURRCOST;
                        new_ckwh_item.ck_avg_unit_cost = gp_item.CURRCOST;
                        new_ckwh_item.created_by = user_id;
                        new_ckwh_item.created_date = DateTime.Now;
                        _ckcontext.ckwh_items.Add(new_ckwh_item);

                        ckwh_items_log new_ckwh_item_log = new ckwh_items_log();
                        new_ckwh_item_log.wh_item_code = gp_item.ITEMNMBR;
                        new_ckwh_item_log.wh_item_description = gp_item.ITEMDESC;
                        new_ckwh_item_log.wh_category_description = gp_item.ITMCLSCD;
                        new_ckwh_item_log.wh_unit_description = gp_item.UOMSCHDL;
                        new_ckwh_item_log.quantity = gp_item.QTYAVBLE;
                        new_ckwh_item_log.unit_cost = gp_item.CURRCOST;
                        new_ckwh_item_log.created_by = user_id;
                        new_ckwh_item_log.created_date = DateTime.Now;
                        new_ckwh_item_log.trans_type = "New";
                        _ckcontext.ckwh_items_log.Add(new_ckwh_item_log);
                        _ckcontext.SaveChanges();
                    }
                }

                foreach (VW_Item_QTY gp_item in gp_modified_items)
                {
                    ckwh_items objWHItemToUpdate = (from whitem in _ckcontext.ckwh_items where whitem.wh_item_code == gp_item.ITEMNMBR select whitem).SingleOrDefault();
                    objWHItemToUpdate.wh_item_description = gp_item.ITEMDESC;
                    objWHItemToUpdate.wh_category_description = gp_item.ITMCLSCD;
                    objWHItemToUpdate.wh_unit_description = gp_item.UOMSCHDL;
                    objWHItemToUpdate.quantity = gp_item.QTYAVBLE;
                    objWHItemToUpdate.unit_cost = gp_item.CURRCOST;
                    objWHItemToUpdate.modified_by = user_id;
                    objWHItemToUpdate.modified_date = DateTime.Now;
                    _ckcontext.SaveChanges();
                }
                ctbl.LastLoadDate = DateTime.Now;
                _ckcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                _gpcontext.Dispose();
                _ckcontext.Dispose();
                return 0;
            }
            _gpcontext.Dispose();
            _ckcontext.Dispose();
            return 1;
        }
        public int CKWHItemUpdate1(int user_id)
        {
            try
            {
                _gpcontext = new DIPKWEntities();
                _ckcontext = new CKEntities();

                IEnumerable<VW_Item_QTY> gp_items = (from gpitem in _gpcontext.VW_Item_QTY orderby gpitem.ITEMNMBR descending select gpitem);

                //IEnumerable<ckwh_items>ck_wh_items = (from ckwhitem in _ckcontext.ckwh_items orderby ckwhitem.wh_item_code descending select ckwhitem);
                //MessageBox.Show("gp_items");
                foreach (VW_Item_QTY gp_item in gp_items)
                {
                    ckwh_items objWHItemToUpdate = (from whitem in _ckcontext.ckwh_items where whitem.wh_item_code == gp_item.ITEMNMBR select whitem).SingleOrDefault();
                    if (objWHItemToUpdate == null)
                    {
                        ckwh_items new_ckwh_item = new ckwh_items();
                        new_ckwh_item.wh_item_code = gp_item.ITEMNMBR;
                        new_ckwh_item.wh_item_description = gp_item.ITEMDESC;
                        new_ckwh_item.wh_category_description = gp_item.ITMCLSCD;
                        new_ckwh_item.wh_unit_description = gp_item.UOMSCHDL;
                        new_ckwh_item.quantity = gp_item.QTYAVBLE;
                        new_ckwh_item.unit_cost = gp_item.CURRCOST;
                        new_ckwh_item.ck_avg_unit_cost = gp_item.CURRCOST;
                        new_ckwh_item.created_by = user_id;
                        new_ckwh_item.created_date = DateTime.Now;
                        _ckcontext.ckwh_items.Add(new_ckwh_item);

                        ckwh_items_log new_ckwh_item_log = new ckwh_items_log();
                        new_ckwh_item_log.wh_item_code = gp_item.ITEMNMBR;
                        new_ckwh_item_log.wh_item_description = gp_item.ITEMDESC;
                        new_ckwh_item_log.wh_category_description = gp_item.ITMCLSCD;
                        new_ckwh_item_log.wh_unit_description = gp_item.UOMSCHDL;
                        new_ckwh_item_log.quantity = gp_item.QTYAVBLE;
                        new_ckwh_item_log.unit_cost = gp_item.CURRCOST;
                        new_ckwh_item_log.created_by = user_id;
                        new_ckwh_item_log.created_date = DateTime.Now;
                        new_ckwh_item_log.trans_type = "New";
                        _ckcontext.ckwh_items_log.Add(new_ckwh_item_log);

                        _ckcontext.SaveChanges();
                    }
                    else
                    {
                        objWHItemToUpdate.wh_item_description = gp_item.ITEMDESC;
                        objWHItemToUpdate.wh_category_description = gp_item.ITMCLSCD;
                        objWHItemToUpdate.wh_unit_description = gp_item.UOMSCHDL;
                        objWHItemToUpdate.quantity = gp_item.QTYAVBLE;
                        objWHItemToUpdate.unit_cost = gp_item.CURRCOST;
                        objWHItemToUpdate.ck_avg_unit_cost = gp_item.CURRCOST;
                        objWHItemToUpdate.modified_by = user_id;
                        objWHItemToUpdate.modified_date = DateTime.Now;

                        //ckwh_items_log new_ckwh_item_log = new ckwh_items_log();
                        //new_ckwh_item_log.wh_item_code = gp_item.ITEMNMBR;
                        //new_ckwh_item_log.wh_item_description = gp_item.ITEMDESC;
                        //new_ckwh_item_log.wh_category_description = gp_item.ITMCLSCD;
                        //new_ckwh_item_log.wh_unit_description = gp_item.UOMSCHDL;
                        //new_ckwh_item_log.quantity = gp_item.QTYAVBLE;
                        //new_ckwh_item_log.unit_cost = gp_item.CURRCOST;
                        //new_ckwh_item_log.created_by = user_id;
                        //new_ckwh_item_log.created_date = DateTime.Now;
                        //new_ckwh_item_log.trans_type = "Update";
                        //_ckcontext.ckwh_items_log.Add(new_ckwh_item_log);

                        _ckcontext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
                MessageBox.Show(ex.Message.ToString());
                _gpcontext.Dispose();
                _ckcontext.Dispose();
                return 0;
            }
            _gpcontext.Dispose();
            _ckcontext.Dispose();
            return 1;
        }
    }
}
