from application import application
from flask import flash, request
import sqlhelper
from authhelper import require_appkey

@application.route('/projectfunder', methods=['POST'])
@require_appkey
def projectfunder_add():
    try:
        content = request.json
        _projectid = content['ProjectId']
        _categoryid = content['FunderId']
        _amount = content['AmountFunded']

        sql = "CALL usp_AddFunderToProject(%s, %s, %s)"
        data = (_projectid, _categoryid, _amount,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@application.route('/projectfunder/<int:id>', methods=['DELETE'])
@require_appkey
def delete_projectfunder(id):
    try:
        sql = "CALL usp_RemoveFunderFromProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/projectfunder/<int:projectid>', methods=['GET'])
@require_appkey
def projectfunder(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetFundersForProject(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)