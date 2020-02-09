from app import app
from flask import flash, request
import sqlhelper

@app.route('/purchaseditem', methods=['POST'])
def purchaseditem_add():
    try:
        content = request.json
        _projectid = content['ProjectId']
        _purchaseditem = content['PurchasedItem']
        _datepurchased = content['DatePurchased']
        _itemcost = content['ItemCost']

        sql = "CALL usp_AddPurchasedItemToProject(%s, %s, %s, %s)"
        data = (_projectid, _purchaseditem, _datepurchased, _itemcost,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@app.route('/purchaseditems/<int:id>', methods=['DELETE'])
def delete_purchaseditem(id):
    try:
        sql = "CALL usp_RemovePurchasedItemFromProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/purchaseditems/<int:projectid>', methods=['GET'])
def purchaseditem(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetPurchasedItemsForProject(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)